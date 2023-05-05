public sealed class TapFacade : BaseFacade<ITapComponent>, ITapFacade
{
    private TapFacade(ITapComponent item) : base(item) { }
    public bool Tapped => Item.Tapped;
    public void Tap() => Item.Tap();
    public void UnTap() => Item.UnTap();
    public static ITapFacade Get() => new TapFacade(TapComponent.Get());
}