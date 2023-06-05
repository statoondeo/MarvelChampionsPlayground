public sealed class EmptyVillainDeckStateBasedCommand : BaseStateBasedCommand
{
    private readonly string PlayerId;
    private EmptyVillainDeckStateBasedCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override bool Check()
        => Game.GetFirst(ZoneNameSelector.Get(Game, PlayerId, "DECK")).Count(NoFilterCardSelector.Get()) == 0;
    protected override ICommand GetCommand()
        => CompositeCommand.Get(
                Game,
                TransactionCommand.Get(
                    Game,
                    AddAccelerationTokenCommand.Get(Game)),
                TransactionCommand.Get(
                    Game,
                    MoveZoneToZoneCommand.Get(Game, PlayerId, "DISCARD", "DECK")),
                TransactionCommand.Get(
                    Game,
                    ShuffleDeckCommand.Get(Game, Game.GetFirst(PlayerIdSelector.Get(PlayerId)).GetZone("DECK"))));
    public static IStateBasedCommand Get(IGame game, string playerId) => new EmptyVillainDeckStateBasedCommand(game, playerId);
}
