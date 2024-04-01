namespace ChainOfResponsibility.V2.Abstractions;

public interface IRepository<TModel, in TCriteria>
    where TModel : class
    where TCriteria : ISearchCriteria
{
    Task<List<TModel>> FindAsync(TCriteria criteria, CancellationToken cancellationToken);
    Task SaveAsync(TModel model, CancellationToken cancellationToken);
}

public interface ISearchCriteria
{ }