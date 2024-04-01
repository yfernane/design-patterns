using ChainOfResponsibility.V2.Abstractions;

namespace ChainOfResponsibility.V2.ValidateOrder.Data;

public interface IOrderRepository : IRepository<Order, OrderSearchCriteria>
{
}

internal sealed class OrderRepository : IOrderRepository
{
    public Task<List<Order>> FindAsync(OrderSearchCriteria criteria, CancellationToken cancellationToken)
    {
        return Task.FromResult(new List<Order>
        {
            new(

                Guid.NewGuid(),
                new Product(Guid.NewGuid(), "My awesome product", 120, 10),
                10,
                OrderStatus.Pending)
        });
    }

    public Task SaveAsync(Order model, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

internal static class OrderRepositoryExtensions
{
    public static Task<Order?> GetByIdAsync(this IOrderRepository repository, Guid id, CancellationToken cancellationToken)
    {
        return repository
            .FindAsync(new OrderSearchCriteria { Id = id }, cancellationToken)
            .ContinueWith(task => task.Result.FirstOrDefault(), cancellationToken);
    }
}