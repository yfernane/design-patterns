namespace ChainOfResponsibility.V2.Abstractions;

public interface IStepContext<out TId, out TItem>
{
    TId Id { get; }
    TItem Item { get; }
    Enum? SkipToStep { get; set; }
}