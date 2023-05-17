public sealed class SetAsideObligationsCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private SetAsideObligationsCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => PlayerObligationSelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => MoveToCommand.Get(Game, card, "EXIL");
    public static ICommand Get(IGame game, string playerId) => new SetAsideObligationsCommand(game, playerId);
}
