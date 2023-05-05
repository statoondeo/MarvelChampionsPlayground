public sealed class WhenRevealedFacade : BaseFacade<IWhenRevealedComponent>, IWhenRevealedFacade
{
    private WhenRevealedFacade(IWhenRevealedComponent item) : base(item) { }
    public ICommand WhenRevealed => Item.WhenRevealed;
    public static IWhenRevealedFacade Get(ICommand whenRevealed) 
        => new WhenRevealedFacade(WhenRevealedComponent.Get(whenRevealed));
}