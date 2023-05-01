public sealed class BoostFacade 
    : BaseComponentFacade<IBoostComponent>, 
    IBoostFacade
{
    private BoostFacade(IBoostComponent item) : base(item) { }

    #region IBoost

    public int Boost => Item.Boost;

    #endregion

    public static IBoostFacade Get(int Boost) 
        => new BoostFacade(BoostComponent.Get(Boost));
}