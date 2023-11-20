using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public class SecurityValidationHandler : IValidationHandler
{
    private IValidationHandler? _nextHandler;
    
    public void SetNext(IValidationHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public void Handle(ValidationContext context)
    {
        if (context.Data.Length > 10)
            throw new ArgumentException("Data is too long, security check failed");
        
        Console.WriteLine("2 - Security validation passed");

        _nextHandler?.Handle(context);
        
        Console.WriteLine("2 - Security validation finished");
    }
}