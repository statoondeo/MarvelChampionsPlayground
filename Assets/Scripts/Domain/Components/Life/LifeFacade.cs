using System;

public sealed class LifeFacade : ILifeFacade
{
    private readonly IFacade<ILifeComponent> Facade;
    private LifeFacade(ILifeComponent item) => Facade = FacadeComponent<ILifeComponent>.Get(item);

    #region IFacade<ILife>

    public ILifeComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ILife

    public Action<ILifeComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Life => Item.Life;

    #endregion

    public static ILifeFacade Get(int life) => new LifeFacade(LifeComponent.Get(life));
}