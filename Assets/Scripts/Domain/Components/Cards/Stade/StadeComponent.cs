public sealed class StadeComponent : BaseCardComponent<IStadeComponent>, IStadeComponent
{
    public int Stade { get; private set; }
    private StadeComponent(int stade) : base()
    {
        Stade = stade;
    }
    public static IStadeComponent Get(int stade) => new StadeComponent(stade);
}
