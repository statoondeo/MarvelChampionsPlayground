using System;

public sealed class TapFacade : ITapFacade
{
    private readonly IFacade<ITapComponent> Facade;
    private TapFacade(ITapComponent item) => Facade = FacadeComponent<ITapComponent>.Get(item);

    #region IFacade<ITapComponent>

    public ITapComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ITapComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITapComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITapComponent

    public Action<ITapComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public bool Tapped => Item.Tapped;
    public void Tap() => Item.Tap();
    public void UnTap() => Item.UnTap();

    #endregion

    public static ITapFacade Get() => new TapFacade(TapComponent.Get());
}