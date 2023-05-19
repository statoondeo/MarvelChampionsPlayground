public sealed class HandSizeComponent : BaseCardComponent<IHandSizeComponent>, IHandSizeComponent
{
    public int HandSize { get; private set; }
    public HandSizeComponent(int handSize) : base()
    {
        HandSize = handSize;
    }
    public static IHandSizeComponent Get(int handSize) => new HandSizeComponent(handSize);

}
