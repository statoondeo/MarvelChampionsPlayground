public sealed class StadeComponent : IStade
{
    public int Stade { get; private set; }
    private StadeComponent(int stade) => Stade = stade;
    public static IStade Get(int stade) => new StadeComponent(stade);

}
