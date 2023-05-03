public sealed class MulliganCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private MulliganCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            PlayerIdentitySelector.Get(PlayerId),
            LocationSelector.Get("HAND"));
    protected override ICommand GetCardCommand(ICard card)
        => MoveToCommand.Get(Game, card, "DISCARD");
    protected override IPicker<ICard> CardPicker => Game.AnyCardPicker;
    protected override ICommand GetAdditionalCommand() => DrawUpToHandCommand.Get(Game, PlayerId);
    public static ICommand Get(IGame game, string playerId) => new MulliganCommand(game, playerId);
}
