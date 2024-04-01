using ChainOfResponsibility.V2.Abstractions;
using ChainOfResponsibility.V2.ValidateOrder.Context;
using ChainOfResponsibility.V2.ValidateOrder.Steps;

namespace ChainOfResponsibility.V2.ValidateOrder;

public abstract class ValidateOrderPipelineBase : Pipeline<IValidateOrderStep, IValidateOrderContext, Guid, Order>
{ }

internal sealed class ValidateOrderPipeline : ValidateOrderPipelineBase
{
    public ValidateOrderPipeline(
        LoadOrderStep loadOrderStep,
        ValidateOrderStep validateOrderStep,
        ValidateProductStep validateProductStep,
        CompleteOrderStep completeOrderStep)
    {
        AddStep(loadOrderStep)
            .AddStep(validateOrderStep)
            .AddStep(validateProductStep)
            .AddStep(completeOrderStep);
    }

    public List<IValidateOrderStep> Steps => new();
}