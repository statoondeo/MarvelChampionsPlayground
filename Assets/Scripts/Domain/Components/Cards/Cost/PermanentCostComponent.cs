public sealed class PermanentCostComponent : BaseCostComponent
{
    private PermanentCostComponent(int cost) : base(cost) { }
    public override void Resolve() => Card.MoveTo("BATTLEFIELD");
    public static ICostComponent Get(int cost) => new PermanentCostComponent(cost);
}
