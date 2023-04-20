public interface IHandSize { int HandSize { get; } }
public sealed class HandSizeComponent : IHandSize
{
    public int HandSize { get; private set; }
    public HandSizeComponent(int handSize) => HandSize = handSize;
}