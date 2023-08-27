using System.Collections.Immutable;

namespace Prolexy.IssueInsurance.Domains.Core;

public interface IIdentifier
{
    string Value { get; }
}

public interface ICommand<out TKey> where TKey : IIdentifier
{
    TKey Id { get; }
}

public interface IExecute<in T, TKey> where T : ICommand<TKey> where TKey : IIdentifier
{
    ImmutableArray<IDomainEvent<TKey>> Execute(T command);
}

public interface IDomainEvent<out TKey> where TKey : IIdentifier
{
    Guid EventId { get; }
    string AggregateName { get; }
    TKey AggregateId { get; }
    DateTime PublishedAt { get; }
}

public record  DomainEvent< TKey>
    (Guid EventId, string AggregateName, TKey AggregateId, DateTime PublishedAt)
    : IDomainEvent<TKey>where TKey : IIdentifier;