using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Data;

public record OrderSearchCriteria : ISearchCriteria
{
    public Guid? Id { get; init; }
}