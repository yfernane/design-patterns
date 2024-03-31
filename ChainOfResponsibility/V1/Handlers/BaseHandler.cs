using ChainOfResponsibility.V1.Interfaces;
using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1.Handlers;

public abstract class BaseHandler : IHandler
{
    protected IHandler? NextHandler;

    public IHandler SetNext(IHandler nextHandler)
    {
        NextHandler = nextHandler;

        return NextHandler;
    }

    public abstract void Handle(ValidationContext context);
}