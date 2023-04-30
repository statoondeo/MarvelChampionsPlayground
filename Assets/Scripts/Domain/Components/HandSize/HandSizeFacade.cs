using System;

public sealed class HandSizeFacade : IHandSizeFacade
{
    private readonly IFacade<IHandSizeComponent> Facade;
    private HandSizeFacade(IHandSizeComponent item) => Facade = FacadeComponent<IHandSizeComponent>.Get(item);

    #region IFacade<IHandSize>

    public IHandSizeComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IHandSizeComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IHandSizeComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IHandSize

    public Action<IHandSizeComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int HandSize => Item.HandSize;

    #endregion

    public static IHandSizeFacade Get(int handSize) => new HandSizeFacade(HandSizeComponent.Get(handSize));
}