namespace ChainOfResponsibility.V2.Abstractions;

public interface IStepContext<out TId, TItem>
{
    string? ErrorMessage { get; set; }
    TId Id { get; }
    TItem Item { get; set; }
    Enum? SkipToStep { get; set; }
}