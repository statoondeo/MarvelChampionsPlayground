public sealed class WhenRevealedFacade : BaseCardComponentFacade<IWhenRevealedComponent>, IWhenRevealedFacade
{
    private WhenRevealedFacade(IWhenRevealedComponent item) : base(item) { }
    public ICommand WhenRevealed => Item.WhenRevealed;
    public void Reveal() => Item.Reveal();
    public static IWhenRevealedFacade Get(IWhenRevealedComponent item) 
        => new WhenRevealedFacade(item);
}