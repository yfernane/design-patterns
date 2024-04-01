using ChainOfResponsibility.V2.ValidateOrder.Contracts;
using ChainOfResponsibility.V2.ValidateOrder.Steps;

namespace ChainOfResponsibility.V2.ValidateOrder;

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

    public List<IValidateOrderStep> Steps => new ();
}