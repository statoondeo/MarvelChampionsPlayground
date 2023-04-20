public interface ICost { int Cost { get; } }
public sealed class CostComponent : ICost
{
    public int Cost { get; private set; }
    public CostComponent(int cost) => Cost = cost;
}
