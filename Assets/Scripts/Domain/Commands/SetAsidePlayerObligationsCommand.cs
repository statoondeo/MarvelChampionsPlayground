public sealed class SetAsidePlayerObligationsCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private SetAsidePlayerObligationsCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> GetCardSelector()
        => PlayerObligationSelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "EXIL"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new SetAsidePlayerObligationsCommand(game, playerId);
}
