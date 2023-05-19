public sealed class BoostComponent : BaseCardComponent<IBoostComponent>, IBoostComponent
{
    public int Boost { get; private set; }
    private BoostComponent(int boost) : base() => Boost = boost;
    public static IBoostComponent Get(int boost) => new BoostComponent(boost);
}
