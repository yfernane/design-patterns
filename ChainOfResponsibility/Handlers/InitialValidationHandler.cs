using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public class InitialValidationHandler : IValidationHandler
{
    private IValidationHandler? _nextHandler;
    
    public void SetNext(IValidationHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public void Handle(ValidationContext context)
    {   
        Console.WriteLine("Initial validation started");
        
        if (context is null)
            throw new ArgumentNullException(nameof(context), "Context is null");
        
        if (context.Data is null)
            throw new ArgumentException("Data is null");
        
        Console.WriteLine("Initial validation passed");

        _nextHandler?.Handle(context);
        
        Console.WriteLine("Initial validation finished");
    }
}