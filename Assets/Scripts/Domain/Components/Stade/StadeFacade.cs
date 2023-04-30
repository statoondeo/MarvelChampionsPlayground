using System;

public sealed class StadeFacade : IStadeFacade
{
    private readonly IFacade<IStadeComponent> Facade;
    private StadeFacade(IStadeComponent item) => Facade = FacadeComponent<IStadeComponent>.Get(item);

    #region IFacade<IStade>

    public IStadeComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IStadeComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IStadeComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IStade

    public Action<IStadeComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Stade => Item.Stade;

    #endregion

    public static IStadeFacade Get(int Stade) => new StadeFacade(StadeComponent.Get(Stade));

}