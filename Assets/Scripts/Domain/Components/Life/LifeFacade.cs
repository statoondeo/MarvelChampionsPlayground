public sealed class LifeFacade : BaseComponentFacade<ILifeComponent>, ILifeFacade
{
    private LifeFacade(ILifeComponent item): base(item) { }

    #region ILife

    public int CurrentLife => Item.CurrentLife;
    public int TotalLife => Item.TotalLife;
    public int Damage => Item.Damage;
    public void TakeDamage(int damage) => Item.TakeDamage(damage);

    #endregion

    public static ILifeFacade Get(int life) => new LifeFacade(LifeComponent.Get(life));
}