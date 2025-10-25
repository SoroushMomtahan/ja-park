using JaPark.Shared.Domain.Events;
using JaPark.Shared.Domain.Objects;
using JaPark.Shared.Infrastructure.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace JaPark.Shared.Infrastructure.Outbox;

public class InsertOutboxMessageInterceptor
    : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not null)
        {
            await InsertOutboxMessage(eventData.Context);
        }
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private static async Task InsertOutboxMessage(DbContext context)
    {
        var outboxMessages = context
            .ChangeTracker
            .Entries<Aggregate>()
            .Where(a => a.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                IReadOnlyCollection<IDomainEvent> domainEvents = entity.DomainEvents;
                entity.Clear();
                return domainEvents;
            })
            .Select(domainEvent=> new OutboxMessage()
            {
                Id = domainEvent.Id,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(domainEvent, SerializerSettings.Instance),
                OccurredOnUtc = domainEvent.OccuredOn
            })
            .ToList();
        
        await context.Set<OutboxMessage>().AddRangeAsync(outboxMessages);
    }
}
