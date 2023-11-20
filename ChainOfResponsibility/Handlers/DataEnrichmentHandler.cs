using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public class DataEnrichmentHandler : IValidationHandler
{
    private IValidationHandler? _nextHandler;
    
    public void SetNext(IValidationHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public void Handle(ValidationContext context)
    {
        if (context.ValidationCode is not null)
            throw new ArgumentException("Validation code is already set, context is not valid");
        
        context.ValidationCode = Guid.NewGuid().ToString();
        Console.WriteLine("4 - Data enrichment passed");

        _nextHandler?.Handle(context);
        
        Console.WriteLine("4 - Data enrichment finished");
    }
}