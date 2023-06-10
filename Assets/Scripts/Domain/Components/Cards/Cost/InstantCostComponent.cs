using System.Collections;

public class InstantCostComponent : BaseCostComponent
{
    public InstantCostComponent(int cost) : base(cost) { }
    public override IEnumerator Resolve()
    {
        Card.MoveTo("DISCARD");
        yield return null;
    }

    public static ICostComponent Get(int cost) => new InstantCostComponent(cost);   
}
