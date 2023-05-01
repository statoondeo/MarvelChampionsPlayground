public sealed class StadeFacade : BaseComponentFacade<IStadeComponent>, IStadeFacade
{
    private StadeFacade(IStadeComponent item) : base(item) { }

    #region IStade

    public int Stade => Item.Stade;

    #endregion

    public static IStadeFacade Get(int Stade) => new StadeFacade(StadeComponent.Get(Stade));

}