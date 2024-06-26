using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1.Handlers;

public class BusinessValidationHandler : BaseHandler
{
    public override void Handle(ValidationContext context)
    {
        if(!context.IsValid)
            throw new ArgumentException("Business validation failed, context is not valid");

        Console.WriteLine("3 - Business validation passed");

        NextHandler?.Handle(context);

        Console.WriteLine("3 - Business validation finished");
    }
}