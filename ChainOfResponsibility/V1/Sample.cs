using ChainOfResponsibility.V1.Handlers;
using ChainOfResponsibility.V1.Models;

namespace ChainOfResponsibility.V1;

public class Sample
{
    private readonly InitialValidationHandler _initialValidator;
    private readonly SecurityValidationHandler _securityValidator;
    private readonly BusinessValidationHandler _businessValidator;
    private readonly DataEnrichmentHandler _enricher;

    public Sample()
    {
        _initialValidator = new InitialValidationHandler();
        _securityValidator = new SecurityValidationHandler();
        _businessValidator = new BusinessValidationHandler();
        _enricher = new DataEnrichmentHandler();
    }
    
    public void Run()
    {
        // This determine the execution order of our handlers
        _initialValidator
            .SetNext(_securityValidator)
            .SetNext(_businessValidator)
            .SetNext(_enricher);
    
        // This is the data we want to validate
        var validData = new ValidationContext("Some data", IsValid: true);
        var invalidData = new ValidationContext("Some data", IsValid: false);
    
        // This will execute the chain of handlers
        try
        {
            Console.WriteLine("Process valid data");
            _initialValidator.Handle(validData);
            
            Console.WriteLine("Process invalid data");
            _initialValidator.Handle(invalidData);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}