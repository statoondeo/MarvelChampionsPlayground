public sealed class LifeComponent : BaseComponent<ILifeComponent>, ILifeComponent
{
    public int CurrentLife => TotalLife - Damage;
    public int TotalLife { get; private set; }
    public int Damage { get; private set; }
    private LifeComponent(int life) : base()
    {
        TotalLife = life;
        Damage = 0;
    }
    public void TakeDamage(int damage)
    {
        if (damage == 0) return;
        Damage += damage;
        Notify(this);
    }

    public static ILifeComponent Get(int life) => new LifeComponent(life);
}
