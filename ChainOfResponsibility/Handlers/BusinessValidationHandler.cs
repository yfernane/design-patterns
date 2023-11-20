using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public class BusinessValidationHandler : IValidationHandler
{
    private IValidationHandler? _nextHandler;

    public void SetNext(IValidationHandler? nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public void Handle(ValidationContext context)
    {
        if (!context.IsValid)
            throw new ArgumentException("Business validation failed, context is not valid");
        
        Console.WriteLine("3 - Business validation passed");

        _nextHandler?.Handle(context);
        
        Console.WriteLine("3 - Business validation finished");
    }
}