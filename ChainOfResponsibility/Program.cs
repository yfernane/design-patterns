using ChainOfResponsibility.Handlers;
using ChainOfResponsibility.Models;

var initialValidator = new InitialValidationHandler();
var securityValidator = new SecurityValidationHandler();
var businessValidator = new BusinessValidationHandler();
var enricher = new DataEnrichmentHandler();

// This determine the execution order of our handlers
initialValidator.SetNext(securityValidator);
securityValidator.SetNext(businessValidator);
businessValidator.SetNext(enricher);

// This is the data we want to validate
var data = new ValidationContext("Some data", IsValid: true);

// This will execute the chain of handlers
initialValidator.Handle(data);