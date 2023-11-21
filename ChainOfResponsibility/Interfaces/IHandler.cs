using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Interfaces;

public interface IHandler
{
    IHandler SetNext(IHandler nextHandler);
    void Handle(ValidationContext context);
}