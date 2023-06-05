public sealed class EmptyPlayerDeckStateBasedCommand : BaseStateBasedCommand
{
    private readonly string PlayerId;
    private EmptyPlayerDeckStateBasedCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override bool Check() 
        => Game.GetFirst(ZoneNameSelector.Get(Game, PlayerId, "DECK")).Count(NoFilterCardSelector.Get()) == 0;

    protected override ICommand GetCommand()
        => CompositeCommand.Get(
                Game,
                TransactionCommand.Get(
                    Game,
                    DealEncounterCardCommand.Get(Game, 
                        Game.GetFirst(PlayerTypeSelector.Get(HeroType.Villain)) as IVillainActor,
                        Game.GetFirst(PlayerIdSelector.Get(PlayerId)) as IPlayerActor)),
                TransactionCommand.Get(
                    Game,
                    MoveZoneToZoneCommand.Get(Game, PlayerId, "DISCARD", "DECK")),
                TransactionCommand.Get(
                    Game, 
                    ShuffleDeckCommand.Get(Game, Game.GetFirst(PlayerIdSelector.Get(PlayerId)).GetZone("DECK"))));
    public static IStateBasedCommand Get(IGame game, string playerId) => new EmptyPlayerDeckStateBasedCommand(game, playerId);
}
