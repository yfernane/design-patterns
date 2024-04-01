namespace ChainOfResponsibility.V2.ValidateOrder.Context;

public enum ValidateOrderSteps
{
    LoadOrder = 1,
    ValidateOrder = 2,
    ValidateProduct = 3,
    CompleteOrder = 4
}