public sealed class InstantCostComponent : BaseCostComponent
{
    private InstantCostComponent(int cost) : base(cost) { }
    public override void Resolve() => Card.MoveTo("DISCARD");
    public static ICostComponent Get(int cost) => new InstantCostComponent(cost);   
}
