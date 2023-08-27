using Prolexy.IssueInsurance.Domains.Core;
using Prolexy.IssueInsurance.Domains.CustomerAgg;

namespace Prolexy.IssueInsurance.Domains.CarBodyInsuranceAgg;

public record CarBodyInsuranceId(string Value) : IIdentifier
{
    public static CarBodyInsuranceId New => new CarBodyInsuranceId(Guid.NewGuid().ToString());
}

public interface ICarBodyInsurance : IAggregateRoot<CarBodyInsuranceId, CarBodyInsuranceState>,
    IExecute<IssueCarBodyInsurance, CarBodyInsuranceId>
{
}

public record IssueCarBodyInsurance(CarBodyInsuranceId Id, 
    CustomerId CustomerId,
    bool TheftCoverage,
    bool NaturalDisasterCoverage,
    int DamageUnUseHistory,
    decimal BasicPremium,
    decimal DiscountPercentage,
    decimal AdditionalCoverage) : ICommand<CarBodyInsuranceId>;

public record CarBodyInsuranceIssued
(Guid EventId, CarBodyInsuranceId AggregateId, CustomerId CustomerId,
    bool TheftCoverage,
    bool NaturalDisasterCoverage,
    int DamageUnUseHistory,
    decimal BasicPremium,
    decimal DiscountPercentage,
    decimal AdditionalCoverage,
    DateTime PublishedAt) :
    DomainEvent<CarBodyInsuranceId>(EventId, nameof(CarBodyInsurance), AggregateId, PublishedAt)
{
    public static CarBodyInsuranceIssued CreateFrom(IssueCarBodyInsurance command) =>
        new(Guid.NewGuid(), 
            command.Id,
            command.CustomerId,
            command.TheftCoverage,
            command.NaturalDisasterCoverage,
            command.DamageUnUseHistory,
            command.BasicPremium,
            command.DiscountPercentage,
            command.AdditionalCoverage,
            DateTime.Now);
}

public record CarBodyInsuranceState(
    CustomerId CustomerId,
    bool TheftCoverage,
    bool NaturalDisasterCoverage,
    int DamageUnUseHistory,
    decimal BasicPremium,
    decimal DiscountPercentage,
    decimal AdditionalCoverage);