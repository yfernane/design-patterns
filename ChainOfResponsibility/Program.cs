using ChainOfResponsibility.Handlers;
using ChainOfResponsibility.Models;

var initialValidator = new InitialValidationHandler();
var securityValidator = new SecurityValidationHandler();
var businessValidator = new BusinessValidationHandler();
var enricher = new DataEnrichmentHandler();

// This determine the execution order of our handlers
initialValidator
    .SetNext(securityValidator)
    .SetNext(businessValidator)
    .SetNext(enricher);

// This is the data we want to validate
var validData = new ValidationContext("Some data", IsValid: true);
var invalidData = new ValidationContext("Some data", IsValid: false);

// This will execute the chain of handlers
try
{
    Console.WriteLine("Process valid data");
    initialValidator.Handle(validData);
    
    Console.WriteLine("Process invalid data");
    initialValidator.Handle(invalidData);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}