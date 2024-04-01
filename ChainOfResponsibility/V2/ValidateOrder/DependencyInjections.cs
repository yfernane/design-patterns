using ChainOfResponsibility.V2.ValidateOrder.Data;
using ChainOfResponsibility.V2.ValidateOrder.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsibility.V2.ValidateOrder;

internal static class DependencyInjections
{
	public static IServiceCollection AddValidateOrder(this IServiceCollection services)
	{
		return services
	       .AddRepositories()
	       .AddReleaseOrderItemSteps();
	}
	
	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		return services.AddScoped<IOrderRepository, OrderRepository>();
	}
	
	private static IServiceCollection AddReleaseOrderItemSteps(this IServiceCollection services)
	{
		// Add steps
		services.AddTransient<LoadOrderStep>();
		services.AddTransient<ValidateOrderStep>();
		services.AddTransient<ValidateProductStep>();
		services.AddTransient<CompleteOrderStep>();

		// Add pipeline
		return services.AddSingleton<ValidateOrderPipeline>();
	}
}