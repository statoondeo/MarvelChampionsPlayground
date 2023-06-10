using System.Collections;

public sealed class CostFacade : BaseCardComponentFacade<ICostComponent>, ICostFacade
{
    private CostFacade(ICostComponent item) : base(item) {}
    public int Cost => Item.Cost;
    public void Play() => Item.Play();
    public IEnumerator Resolve() => Item.Resolve();
    public static ICostFacade Get(ICostComponent item) => new CostFacade(item);
}