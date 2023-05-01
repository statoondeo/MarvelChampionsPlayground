public sealed class WhenRevealedFacade : BaseComponentFacade<IWhenRevealedComponent>, IWhenRevealedFacade
{
    private WhenRevealedFacade(IWhenRevealedComponent item) : base(item) { }

    #region IWhenRevealed

    public ICommand WhenRevealed => Item.WhenRevealed;

    #endregion

    public static IWhenRevealedFacade Get(ICommand whenRevealed) 
        => new WhenRevealedFacade(WhenRevealedComponent.Get(whenRevealed));
}