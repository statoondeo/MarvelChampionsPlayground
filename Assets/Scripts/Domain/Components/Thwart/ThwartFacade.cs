using System;

public sealed class ThwartFacade : IThwartFacade
{
    private readonly IFacade<IThwartComponent> Facade;
    private ThwartFacade(IThwartComponent item) => Facade = FacadeComponent<IThwartComponent>.Get(item);

    #region IFacade<IThwart>

    public IThwartComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IThwartComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IThwartComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IThwart

    public Action<IThwartComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Thwart => Item.Thwart;

    #endregion

    public static IThwartFacade Get(int thwart) => new ThwartFacade(ThwartComponent.Get(thwart));

}