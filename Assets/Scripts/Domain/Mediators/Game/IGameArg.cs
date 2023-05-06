public interface IGameArg { }
public sealed class OnCardMovedGameArg : IGameArg
{
    public IZone Zone { get; private set; }
    public ICard Card { get; private set; }
    private OnCardMovedGameArg(IZone zone, ICard card)
    {
        Zone = zone;
        Card = card;
    }
    public static IGameArg Get(IZone zone, ICard card) => new OnCardMovedGameArg(zone, card);
}
