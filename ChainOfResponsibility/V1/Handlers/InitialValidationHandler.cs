using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1.Handlers;

public class InitialValidationHandler : BaseHandler
{
    public override void Handle(ValidationContext context)
    {
        if(context is null)
            throw new ArgumentNullException(nameof(context), "Context is null");

        if(context.Data is null)
            throw new ArgumentException("Data is null");

        Console.WriteLine("1 - Initial validation passed");

        NextHandler?.Handle(context);

        Console.WriteLine("1 - Initial validation finished");
    }
}