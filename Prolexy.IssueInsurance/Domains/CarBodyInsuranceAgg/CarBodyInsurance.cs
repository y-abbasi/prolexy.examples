using System.Collections.Immutable;
using Prolexy.IssueInsurance.Domains.Core;

namespace Prolexy.IssueInsurance.Domains.CarBodyInsuranceAgg;

public class CarBodyInsurance : AggregateRoot<CarBodyInsuranceId, CarBodyInsuranceState>,
    ICarBodyInsurance
{
    public CarBodyInsurance(CarBodyInsuranceId id) : base(id)
    {
    }

    public ImmutableArray<IDomainEvent<CarBodyInsuranceId>> Execute(IssueCarBodyInsurance command)
    {
        // check business rules here.
        return Process(ImmutableArray<IDomainEvent<CarBodyInsuranceId>>
            .Empty
            .Add(CarBodyInsuranceIssued.CreateFrom(command)));
    }

    protected override void Apply(IDomainEvent<CarBodyInsuranceId> @event)
    {
        When((dynamic) @event);
    }

    private void When(CarBodyInsuranceIssued @event)
    {
        State = new CarBodyInsuranceState(@event.CustomerId, 
            @event.TheftCoverage,
            @event.NaturalDisasterCoverage,
            @event.DamageUnUseHistory,
            @event.BasicPremium, 
            @event.DiscountPercentage, 
            @event.AdditionalCoverage);
    }
}