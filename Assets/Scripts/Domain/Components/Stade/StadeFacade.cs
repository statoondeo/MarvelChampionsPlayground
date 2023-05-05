public sealed class StadeFacade : BaseFacade<IStadeComponent>, IStadeFacade
{
    private StadeFacade(IStadeComponent item) : base(item) { }
    public int Stade => Item.Stade;
    public static IStadeFacade Get(int Stade) => new StadeFacade(StadeComponent.Get(Stade));

}