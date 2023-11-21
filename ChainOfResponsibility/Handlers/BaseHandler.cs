using ChainOfResponsibility.Interfaces;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Handlers;

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