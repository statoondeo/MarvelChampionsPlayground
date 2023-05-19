public sealed class HandSizeFacade : BaseCardComponentFacade<IHandSizeComponent>, IHandSizeFacade
{
    private HandSizeFacade(IHandSizeComponent item) : base(item) { }
    public int HandSize => Item.HandSize;
    public static IHandSizeFacade Get(int handSize) => new HandSizeFacade(HandSizeComponent.Get(handSize));
}