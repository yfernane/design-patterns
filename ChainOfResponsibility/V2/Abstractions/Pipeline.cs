namespace ChainOfResponsibility.V2.Abstractions;

public abstract class Pipeline<TStep, TContext, TId, TItem>
    where TStep : IStep<TContext, TId, TItem>
    where TContext : IStepContext<TId, TItem>
{
    private readonly List<TStep> _steps = new();

    public Pipeline<TStep, TContext, TId, TItem> AddStep(TStep step)
    {
        _steps.Add(step);

        return this;
    }

    public async Task ExecuteAsync(TContext context, CancellationToken cancellationToken)
    {
        var steps = _steps.OrderBy(x => Convert.ToInt32(x.Step)).ToList();
        for(var index = 0; index < steps.Count; index++)
        {
            await steps[index].ExecuteAsync(context, cancellationToken);
            if(context.SkipToStep is not null)
            {
                var skipToStepValue = context.SkipToStep;
                var skipToStepIndex = steps.FindIndex(s => Convert.ToInt32(s.Step) == Convert.ToInt32(skipToStepValue));
                if(skipToStepIndex >= steps.Count)
                {
                    throw new InvalidOperationException("SkipToStep index is out of range");
                }

                index = skipToStepIndex;
                context.SkipToStep = default;
            }
        }
    }
}