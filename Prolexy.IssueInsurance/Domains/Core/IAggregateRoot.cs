namespace Prolexy.IssueInsurance.Domains.Core;

public interface IAggregateRoot
{
    
}

public interface IAggregateRoot<out TKey, out TState> : IAggregateRoot where TKey : IIdentifier
{
    TKey Id { get; }
    TState? State { get; }
}