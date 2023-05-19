public sealed class EnterPlayFacade : BaseCardComponentFacade<IEnterPlayComponent>, IEnterPlayFacade
{
    private EnterPlayFacade(IEnterPlayComponent item) : base(item) { }
    public void EnterPlay() => Item.EnterPlay();

    public static IEnterPlayFacade Get(IEnterPlayComponent item) => new EnterPlayFacade(item);
}
