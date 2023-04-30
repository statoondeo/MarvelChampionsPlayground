public sealed class Game : IGame
{
    private ICommand SetupCommand;
    public IMediator Mediator { get; private set; }
    public IRepository<string, IZone> Zones { get; private set; }
    public IRepository<string, ICard> Cards { get; private set; }
    public IRepository<string, IPlayer> Players { get; private set; }
    public Game(IMediator mediator)
    {
        Mediator = mediator;
        Zones = new Repository<string, IZone>();
        Cards = new Repository<string, ICard>();
        Players = new Repository<string, IPlayer>();
    }
    public void Commit() => Mediator.Raise(Events.OnGameCommit);
    public void Setup() => SetupCommand.Execute();
    public void RegisterSetupCommand(ICommand command) => SetupCommand = command;
}
