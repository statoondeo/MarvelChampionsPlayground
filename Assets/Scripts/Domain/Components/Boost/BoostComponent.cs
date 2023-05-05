public sealed class BoostComponent : BaseComponent<IBoostComponent>, IBoostComponent
{
    public int Boost { get; private set; }
    private BoostComponent(int boost) : base()
    {
        Type = ComponentType.Boost;
        Boost = boost;
    }
    public static IBoostComponent Get(int boost) => new BoostComponent(boost);
}
