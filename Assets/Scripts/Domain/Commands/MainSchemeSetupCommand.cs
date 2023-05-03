public sealed class MainSchemeSetupCommand : BaseFunctionalCommand
{
    private MainSchemeSetupCommand(IGame game) : base(game) { }
    protected override ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            CardTypeSelector.Get(CardType.MainSchemeA),
            LocationSelector.Get("BATTLEFIELD"));
    protected override ICommand GetCardCommand(ICard card)
        => (card as ISetupFacade).Setup;
    public static ICommand Get(IGame game) => new MainSchemeSetupCommand(game);
}
