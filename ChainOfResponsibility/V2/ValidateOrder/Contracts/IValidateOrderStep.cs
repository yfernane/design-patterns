using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Contracts;

public interface IValidateOrderStep : IStep<IValidateOrderContext, Guid, Order>
{
    Enum IStep<IValidateOrderContext, Guid, Order>.Step => Step;
    public new ValidateOrderSteps Step { get; }
}

public interface IConditionalValidateOrderStep : IValidateOrderStep, IConditionalStep<IValidateOrderContext, Guid, Order>
{
    Enum IConditionalStep<IValidateOrderContext, Guid, Order>.SkipToStep => SkipToStep;
    public new ValidateOrderSteps SkipToStep { get; }
}