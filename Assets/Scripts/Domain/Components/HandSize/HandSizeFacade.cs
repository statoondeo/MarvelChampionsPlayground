public sealed class HandSizeFacade : BaseComponentFacade<IHandSizeComponent>, IHandSizeFacade
{
    private HandSizeFacade(IHandSizeComponent item) : base(item) { }

    #region IHandSize

    public int HandSize => Item.HandSize;

    #endregion

    public static IHandSizeFacade Get(int handSize) => new HandSizeFacade(HandSizeComponent.Get(handSize));
}