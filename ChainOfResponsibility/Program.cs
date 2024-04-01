using ChainOfResponsibility.V2.ValidateOrder;
using Microsoft.Extensions.DependencyInjection;

// V1
// var chainOfResponsibilitySample = new ChainOfResponsibility.V1.Sample();
// chainOfResponsibilitySample.Run();

// V2
var serviceCollection = new ServiceCollection();
serviceCollection.AddValidateOrder();

var pipeline = serviceCollection.BuildServiceProvider().GetRequiredService<ValidateOrderPipeline>()
    ?? throw new InvalidOperationException("Cannot resolve service.");

var sample = new ChainOfResponsibility.V2.Sample(pipeline);
await sample.Run(CancellationToken.None);