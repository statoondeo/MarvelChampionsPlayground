public sealed class CostFacade : BaseFacade<ICostComponent>, ICostFacade
{
    private CostFacade(ICostComponent item) : base(item) {}
    public int Cost => Item.Cost;
    public static ICostFacade Get(int cost) => new CostFacade(CostComponent.Get(cost));
}