using ChainOfResponsibility.V2.Abstractions;
using ChainOfResponsibility.V2.ValidateOrder.Context;

namespace ChainOfResponsibility.V2.ValidateOrder.Steps;

public interface IValidateOrderStep : IStep<IValidateOrderContext, Guid, Order>
{
    public new ValidateOrderSteps Step { get; }
    Enum IStep<IValidateOrderContext, Guid, Order>.Step => Step;
}

public interface IConditionalValidateOrderStep : IValidateOrderStep, IConditionalStep<IValidateOrderContext, Guid, Order>
{
    public new ValidateOrderSteps SkipToStep { get; }
    Enum IConditionalStep<IValidateOrderContext, Guid, Order>.SkipToStep => SkipToStep;
}