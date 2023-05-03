public sealed class HeroSetupCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private HeroSetupCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            PlayerIdentitySelector.Get(PlayerId),
            LocationSelector.Get("BATTLEFIELD"));
    protected override ICommand GetCardCommand(ICard card)
        => (card as ISetupFacade).Setup;
    public static ICommand Get(IGame game, string playerId) => new HeroSetupCommand(game, playerId);
}
