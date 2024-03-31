using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1.Interfaces;

public interface IHandler
{
    IHandler SetNext(IHandler nextHandler);
    void Handle(ValidationContext context);
}