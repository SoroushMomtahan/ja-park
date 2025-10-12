using JaPark.Shared.Domain.Events;

namespace JaPark.Shared.Domain.Objects;

public class Aggregate : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => [.. _domainEvents];
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void Clear()
    {
        _domainEvents.Clear();
    }
}
