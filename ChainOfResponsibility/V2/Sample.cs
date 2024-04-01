using ChainOfResponsibility.V2.ValidateOrder;
using ChainOfResponsibility.V2.ValidateOrder.Context;

namespace ChainOfResponsibility.V2;

internal class Sample
{
    private readonly ValidateOrderPipeline _pipeline;

    public Sample(ValidateOrderPipeline pipeline)
    {
        _pipeline = pipeline;
    }

    public async Task Run(CancellationToken cancellationToken = default)
    {
        var context = new ValidateOrderContext(Guid.NewGuid());

        await _pipeline.ExecuteAsync(context, cancellationToken);
    }
}