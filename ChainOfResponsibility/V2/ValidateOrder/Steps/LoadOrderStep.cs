using ChainOfResponsibility.V2.ValidateOrder.Context;
using ChainOfResponsibility.V2.ValidateOrder.Data;

namespace ChainOfResponsibility.V2.ValidateOrder.Steps;

internal sealed class LoadOrderStep : IConditionalValidateOrderStep
{
    private readonly IOrderRepository _repository;

    public LoadOrderStep(IOrderRepository repository)
    {
        _repository = repository;
    }

    public ValidateOrderSteps Step => ValidateOrderSteps.LoadOrder;
    public ValidateOrderSteps SkipToStep => ValidateOrderSteps.CompleteOrder;

    public async Task ExecuteAsync(IValidateOrderContext context, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(context.Id, cancellationToken);
        if(order is null)
        {
            context.ErrorMessage = $"Order {context.Id} not found";
            context.SkipToStep = ValidateOrderSteps.CompleteOrder;

            return;
        }

        context.Item = order;
        Console.WriteLine("LoadOrderStep executed successfully");
    }
}