namespace ChainOfResponsibility.V2.ValidateOrder.Contracts;

public enum ValidateOrderSteps
{
    LoadOrder = 1,
    ValidateOrder = 2,
    ValidateProduct = 3,
    CompleteOrder = 4
}