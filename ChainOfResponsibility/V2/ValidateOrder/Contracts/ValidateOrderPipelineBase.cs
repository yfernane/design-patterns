using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Contracts;

public abstract class ValidateOrderPipelineBase : Pipeline<IValidateOrderStep, IValidateOrderContext, Guid, Order>
{
}