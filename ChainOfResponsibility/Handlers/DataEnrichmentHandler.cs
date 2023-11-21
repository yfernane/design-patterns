using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public class DataEnrichmentHandler : BaseValidationHandler
{
    public override void Handle(ValidationContext context)
    {
        if (context.ValidationCode is not null)
            throw new ArgumentException("Validation code is already set, context is not valid");
        
        context.ValidationCode = Guid.NewGuid().ToString();
        Console.WriteLine("4 - Data enrichment passed");

        NextHandler?.Handle(context);
        
        Console.WriteLine("4 - Data enrichment finished");
    }
}