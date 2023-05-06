public sealed class GameEventHandler : BaseEventHandler<IGameArg>
{
    private GameEventHandler() : base() { }
    public static IEventHandler<IGameArg> Get() => new GameEventHandler();
}