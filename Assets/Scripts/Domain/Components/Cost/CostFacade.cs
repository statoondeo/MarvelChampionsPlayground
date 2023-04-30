using System;

public sealed class CostFacade : ICostFacade
{
    private readonly IFacade<ICostComponent> Facade;
    private CostFacade(ICostComponent item) => Facade = FacadeComponent<ICostComponent>.Get(item);

    #region IFacade<ICost>

    public ICostComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ICostComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICostComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ICost

    public Action<ICostComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Cost => Item.Cost;

    #endregion

    public static ICostFacade Get(int cost) => new CostFacade(CostComponent.Get(cost));
}