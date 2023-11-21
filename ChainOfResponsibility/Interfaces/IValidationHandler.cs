using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Interfaces;

public interface IValidationHandler
{
    IValidationHandler SetNext(IValidationHandler nextHandler);
    void Handle(ValidationContext context);
}