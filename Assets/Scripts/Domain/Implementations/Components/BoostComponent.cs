public sealed class BoostComponent : IBoost
{
    public int Boost { get; private set; }
    private BoostComponent(int boost) => Boost = boost;
    public static IBoost Get(int boost) => new BoostComponent(boost);

}
