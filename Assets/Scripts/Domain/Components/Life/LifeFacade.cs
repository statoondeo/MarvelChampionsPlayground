public sealed class LifeFacade : BaseComponentFacade<ILifeComponent>, ILifeFacade
{
    private LifeFacade(ILifeComponent item): base(item) { }

    #region ILife

    public int Life => Item.Life;

    #endregion

    public static ILifeFacade Get(int life) => new LifeFacade(LifeComponent.Get(life));
}