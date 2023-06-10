using System.Collections;

public sealed class PermanentCostComponent : BaseCostComponent
{
    private PermanentCostComponent(int cost) : base(cost) { }
    public override IEnumerator Resolve()
    {
        Card.MoveTo("BATTLEFIELD");
        yield return null;
    }

    public static ICostComponent Get(int cost) => new PermanentCostComponent(cost);
}
