public sealed class StadeComponent : BaseComponent<IStadeComponent>, IStadeComponent
{
    public int Stade { get; private set; }
    private StadeComponent(int stade) : base()
    {
        Type = ComponentType.Stade;
        Stade = stade;
    }
    public static IStadeComponent Get(int stade) => new StadeComponent(stade);
}
