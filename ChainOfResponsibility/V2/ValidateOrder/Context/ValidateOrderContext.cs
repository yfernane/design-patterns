using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Context;

public interface IValidateOrderContext : IStepContext<Guid, Order>
{ }

internal sealed record ValidateOrderContext(Guid Id) : IValidateOrderContext
{
    Enum? IStepContext<Guid, Order>.SkipToStep
    {
        get => SkipToStep;
        set => SkipToStep = (ValidateOrderSteps)value!;
    }

    public string? ErrorMessage { get; set; }
    public Order Item { get; set; } = default!;
    public ValidateOrderSteps? SkipToStep { get; set; }
}