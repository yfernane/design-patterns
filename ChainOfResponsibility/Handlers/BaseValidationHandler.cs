using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

public abstract class BaseValidationHandler : IValidationHandler
{
    protected IValidationHandler? NextHandler;

    public IValidationHandler SetNext(IValidationHandler nextHandler)
    {
        NextHandler = nextHandler;

        return NextHandler;
    }

    public abstract void Handle(ValidationContext context);
}