using JaPark.Shared.Domain.Events;
using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Shared.Domain.Objects;

public class Aggregate<T> : Entity<T> where T : PrefixedGuidV3
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

