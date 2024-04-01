using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Contracts;

public interface IValidateOrderContext : IStepContext<Guid, Order>
{
    string? ErrorMessage { get; set; }
    Order Item { get; set; }
    ValidateOrderSteps? SkipToStep { get; set; }
}