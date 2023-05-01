public sealed class InstallHeroCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private InstallHeroCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> GetCardSelector()
        => PlayerIdentitySelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "BATTLEFIELD"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new InstallHeroCommand(game, playerId);
}
