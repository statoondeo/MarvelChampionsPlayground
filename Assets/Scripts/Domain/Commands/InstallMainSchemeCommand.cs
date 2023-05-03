public sealed class InstallMainSchemeCommand : BaseFunctionalCommand
{
    private InstallMainSchemeCommand(IGame game) : base(game) { }
    protected override ISelector<ICard> CardSelector
        => CardTypeSelector.Get(CardType.MainSchemeA);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "BATTLEFIELD"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game) => new InstallMainSchemeCommand(game);
}
