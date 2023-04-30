public sealed class LifeComponent : BaseComponent<ILifeComponent>, ILifeComponent
{
    public int Life { get; private set; }
    private LifeComponent(int life) : base() => Life = life;
    public static ILifeComponent Get(int life) => new LifeComponent(life);
}
