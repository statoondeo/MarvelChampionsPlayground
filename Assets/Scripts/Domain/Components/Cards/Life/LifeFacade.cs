public sealed class LifeFacade : BaseCardComponentFacade<ILifeComponent>, ILifeFacade
{
    private LifeFacade(ILifeComponent item): base(item) { }
    public int CurrentLife => Item.TotalLife - Item.Damage;
    public int TotalLife => Item.TotalLife;
    public int Damage => Item.Damage;
    public void TakeDamage(int damage) => Item.TakeDamage(damage);
    public void HealDamage(int damage) => Item.HealDamage(damage);
    public static ILifeFacade Get(int life) => new LifeFacade(LifeComponent.Get(life));
}
