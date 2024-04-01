using ChainOfResponsibility.V2.ValidateOrder.Contracts;
using ChainOfResponsibility.V2.ValidateOrder.Data;

namespace ChainOfResponsibility.V2.ValidateOrder.Steps;

internal sealed class ValidateProductStep : IValidateOrderStep
{
    private readonly IOrderRepository _repository;

    public ValidateProductStep(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public ValidateOrderSteps Step => ValidateOrderSteps.ValidateProduct;
 
    public async Task ExecuteAsync(IValidateOrderContext context, CancellationToken cancellationToken)
    {
        if(context.Item.Product.Quantity == 0)
        {
            context.ErrorMessage = $"Product {context.Item.Product.Id} is out of stock";
            context.SkipToStep = ValidateOrderSteps.CompleteOrder;

            return;
        }
        
        if (context.Item.Quantity > context.Item.Product.Quantity)
        {
            context.ErrorMessage = $"Product {context.Item.Product.Id} has only {context.Item.Product.Quantity} items in stock";
            context.SkipToStep = ValidateOrderSteps.CompleteOrder;

            return;
        }
        
        context.Item.SubmitOrder();
        Console.WriteLine("ValidateProductStep executed successfully");
        await _repository.SaveAsync(context.Item, cancellationToken);
    }
}