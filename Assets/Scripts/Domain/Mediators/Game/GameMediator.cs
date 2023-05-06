public sealed class GameMediator : BaseMediator<GameEvents, IGameArg>, IGameMediator
{
    private GameMediator() : base(GameEventHandler.Get) { }
    public static IGameMediator Get() => new GameMediator();
}