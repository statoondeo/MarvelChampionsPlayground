public sealed class InstallVillainCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private InstallVillainCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => VillainIdentitySelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => MoveToCommand.Get(Game, card, "BATTLEFIELD");
    public static ICommand Get(IGame game, string playerId) => new InstallVillainCommand(game, playerId);
}
