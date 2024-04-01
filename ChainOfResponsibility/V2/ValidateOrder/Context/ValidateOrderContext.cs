using ChainOfResponsibility.V2.Abstractions;
using ChainOfResponsibility.V2.ValidateOrder.Contracts;

namespace ChainOfResponsibility.V2.ValidateOrder.Context;

internal sealed record ValidateOrderContext(Guid Id) : IValidateOrderContext
{
    Enum? IStepContext<Guid, Order>.SkipToStep { get; set; }
    public string? ErrorMessage { get; set; }
    public Order Item { get; set; } = default!;
    public ValidateOrderSteps? SkipToStep { get; set; }
}