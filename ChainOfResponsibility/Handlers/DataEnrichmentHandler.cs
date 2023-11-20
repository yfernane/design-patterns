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
        _nextHandler?.Handle(context);
    }
}