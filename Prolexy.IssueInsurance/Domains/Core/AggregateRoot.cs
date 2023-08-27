using System.Collections.Immutable;

namespace Prolexy.IssueInsurance.Domains.Core;

public abstract class AggregateRoot<TKey, TState> : IAggregateRoot<TKey, TState> where TKey : IIdentifier
{
    public AggregateRoot(TKey id)
    {
        Id = id;
    }
    public TKey Id { get; }
    public TState? State { get; protected set; } = default(TState);

    protected ImmutableArray<IDomainEvent<TKey>> Process(ImmutableArray<IDomainEvent<TKey>> events)
    {
        foreach (var domainEvent in events) 
            Apply(domainEvent);

        return events;
    }

    protected abstract void Apply(IDomainEvent<TKey> @event);
}