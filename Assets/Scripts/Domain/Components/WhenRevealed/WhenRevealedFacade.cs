using System;

public sealed class WhenRevealedFacade : IWhenRevealedFacade
{
    private readonly IFacade<IWhenRevealedComponent> Facade;
    private WhenRevealedFacade(IWhenRevealedComponent item) => Facade = FacadeComponent<IWhenRevealedComponent>.Get(item);

    #region IFacade<IWhenRevealed>

    public IWhenRevealedComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealed

    public Action<IWhenRevealedComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public ICommand WhenRevealed => Item.WhenRevealed;

    #endregion

    public static IWhenRevealedFacade Get(ICommand whenRevealed) => new WhenRevealedFacade(WhenRevealedComponent.Get(whenRevealed));
}