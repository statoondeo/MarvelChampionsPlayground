using System;

public sealed class BoostFacade : IBoostFacade
{
    private readonly IFacade<IBoostComponent> Facade;
    private BoostFacade(IBoostComponent item) => Facade = FacadeComponent<IBoostComponent>.Get(item);

    #region IFacade<IBoost>

    public IBoostComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IBoostComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IBoost

    public int Boost => Item.Boost;
    public Action<IBoostComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }

    #endregion

    public static IBoostFacade Get(int Boost) => new BoostFacade(BoostComponent.Get(Boost));
}