namespace ChainOfResponsibility.V2.Abstractions;

public interface IStep<in TContext, TId, TItem>
    where TContext : IStepContext<TId, TItem>
{
    Enum Step { get; }
    Task ExecuteAsync(TContext context, CancellationToken cancellationToken);
}

public interface IConditionalStep<in TContext, TId, TItem> : IStep<TContext, TId, TItem>
    where TContext : IStepContext<TId, TItem>
{
    public Enum SkipToStep { get; }
}