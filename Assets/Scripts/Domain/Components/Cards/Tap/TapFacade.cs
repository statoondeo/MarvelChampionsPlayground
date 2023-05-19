public sealed class TapFacade : BaseCardComponentFacade<ITapComponent>, ITapFacade
{
    private TapFacade(ITapComponent item) : base(item) { }

    #region ITapComponent

    public bool Tapped => Item.Tapped;
    public void Tap() => Item.Tap();
    public void UnTap() => Item.UnTap();

    #endregion

    public static ITapFacade Get() => new TapFacade(TapComponent.Get());
}