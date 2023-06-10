using System.Collections;

public abstract class BaseCostComponent : BaseCardComponent<ICostComponent>, ICostComponent
{
    public int Cost { get; private set; }
    protected BaseCostComponent(int cost) : base() => Cost = cost;
    public void Play() => Card.MoveTo("STACK");
    public abstract IEnumerator Resolve();
}
