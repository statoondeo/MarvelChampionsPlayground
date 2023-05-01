public sealed class CostFacade : BaseComponentFacade<ICostComponent>, ICostFacade
{
    private CostFacade(ICostComponent item) : base(item) {}

    #region ICost

    public int Cost => Item.Cost;

    #endregion

    public static ICostFacade Get(int cost) => new CostFacade(CostComponent.Get(cost));
}