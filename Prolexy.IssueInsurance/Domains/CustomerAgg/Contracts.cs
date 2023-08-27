using Prolexy.IssueInsurance.Domains.Core;

namespace Prolexy.IssueInsurance.Domains.CustomerAgg;

public record CustomerId(string Value) : IIdentifier
{
    public static CustomerId New => new CustomerId(Guid.NewGuid().ToString());
}

public interface ICustomer : IAggregateRoot<CustomerId, CustomerAggregateState>
{
    
}

public record CustomerAggregateState(CustomerId Id);