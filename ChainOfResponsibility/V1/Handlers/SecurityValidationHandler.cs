using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1.Handlers;

public class SecurityValidationHandler : BaseHandler
{
    public override void Handle(ValidationContext context)
    {
        if(context.Data.Length > 10)
            throw new ArgumentException("Data is too long, security check failed");

        Console.WriteLine("2 - Security validation passed");

        NextHandler?.Handle(context);

        Console.WriteLine("2 - Security validation finished");
    }
}