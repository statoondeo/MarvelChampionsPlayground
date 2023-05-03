public sealed class ResolveVillainBoardWhenRevealedCommand : BaseFunctionalCommand
{
    private ResolveVillainBoardWhenRevealedCommand(IGame game) : base(game) { }
    protected override ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            OwnerIdSelector.Get(Game.GetFirst(PlayerTypeSelector.Get(HeroType.Villain)).Id),
            LocationSelector.Get("BATTLEFIELD"));
    protected override ICommand GetCardCommand(ICard card)
        => (card as ISetupFacade).Setup;
    public static ICommand Get(IGame game) => new ResolveVillainBoardWhenRevealedCommand(game);
}