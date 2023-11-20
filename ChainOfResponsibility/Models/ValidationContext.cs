namespace ChainOfResponsibility.Models;

public record ValidationContext(string Data, bool IsValid)
{
    public string? ValidationCode { get; internal set; }
}