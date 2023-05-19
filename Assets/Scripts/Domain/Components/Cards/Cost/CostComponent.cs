public sealed class CostComponent : BaseCardComponent<ICostComponent>, ICostComponent
{
    public int Cost { get; private set; }
    private CostComponent(int cost) : base()
    {
        Cost = cost;
    }
    public static ICostComponent Get(int cost) => new CostComponent(cost);

}
