public sealed class InstallHeroCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private InstallHeroCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => PlayerIdentitySelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => MoveToCommand.Get(Game, card, "BATTLEFIELD");
    public static ICommand Get(IGame game, string playerId) => new InstallHeroCommand(game, playerId);
}
