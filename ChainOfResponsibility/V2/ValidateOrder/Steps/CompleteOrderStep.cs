using ChainOfResponsibility.V2.ValidateOrder.Contracts;
using ChainOfResponsibility.V2.ValidateOrder.Data;

namespace ChainOfResponsibility.V2.ValidateOrder.Steps;

internal sealed class CompleteOrderStep : IValidateOrderStep
{
    private readonly IOrderRepository _repository;

    public CompleteOrderStep(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public ValidateOrderSteps Step => ValidateOrderSteps.CompleteOrder;
 
    public async Task ExecuteAsync(IValidateOrderContext context, CancellationToken cancellationToken)
    {
        if(context.ErrorMessage is not null)
        {
            Console.WriteLine(context.ErrorMessage);
            return;
        }
        
        context.Item.CompleteOrder();
        await _repository.SaveAsync(context.Item, cancellationToken);
        Console.WriteLine("CompleteOrderStep executed successfully");
    }
}