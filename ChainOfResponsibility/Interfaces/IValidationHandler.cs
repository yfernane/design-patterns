using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Interfaces;

public interface IValidationHandler
{
    void SetNext(IValidationHandler? nextHandler);
    void Handle(ValidationContext context);
}