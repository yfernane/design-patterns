namespace ChainOfResponsibility.V2.ValidateOrder;

public record Order(Guid Id, Product Product, int Quantity, OrderStatus Status)
{
    public OrderStatus Status { get; private set; } = Status;
    
    public void CompleteOrder() => Status = OrderStatus.Completed;
    public void SubmitOrder() => Status = OrderStatus.Submitted;
}

public record Product(Guid Id, string Name, int PriceInCent, int Quantity);

public enum OrderStatus
{
    Pending = 1,
    Submitted = 2,
    Completed = 3
}