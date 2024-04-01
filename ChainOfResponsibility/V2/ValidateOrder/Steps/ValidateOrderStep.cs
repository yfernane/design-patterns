using ChainOfResponsibility.V2.ValidateOrder.Contracts;

namespace ChainOfResponsibility.V2.ValidateOrder.Steps;

internal sealed class ValidateOrderStep : IValidateOrderStep
{
    public ValidateOrderSteps Step => ValidateOrderSteps.ValidateOrder;
 
    public Task ExecuteAsync(IValidateOrderContext context, CancellationToken cancellationToken)
    {
        if(context.Item is not { Status: OrderStatus.Pending })
        {
            context.ErrorMessage = $"Order {context.Id} is not pending";
            context.SkipToStep = ValidateOrderSteps.CompleteOrder;
        }

        Console.WriteLine("ValidateOrderStep executed successfully");
        return Task.CompletedTask;
    }
}