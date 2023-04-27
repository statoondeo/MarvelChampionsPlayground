public sealed class CostComponent : ICost
{
    public int Cost { get; private set; }
    private CostComponent(int cost) => Cost = cost;
    public static ICost Get(int cost) => new CostComponent(cost);

}
public interface ICostFacade : IFacade<ICost>, ICost { }
public sealed class CostFacade : ICostFacade
{
    private readonly IFacade<ICost> Facade;
    private CostFacade(ICost item) => Facade = FacadeComponent<ICost>.Get(item);

    #region IFacade<ICost>

    public ICost Item { get; private set; }
    public void AddDecorator(IDecorator<ICost> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICost> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ICost

    public int Cost => Item.Cost;

    #endregion

    public static ICostFacade Get(int cost) => new CostFacade(CostComponent.Get(cost));
}