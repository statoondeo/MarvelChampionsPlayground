public sealed class InstallMainSchemeCommand : BaseFunctionalCommand
{
    private InstallMainSchemeCommand(IGame game) : base(game) { }
    protected override ISelector<ICard> CardSelector
        => CardTypeSelector.Get(CardType.MainScheme);
    protected override ICommand GetCardCommand(ICard card)
        => MoveToCommand.Get(Game, card, "BATTLEFIELD");
    public static ICommand Get(IGame game) => new InstallMainSchemeCommand(game);
}
