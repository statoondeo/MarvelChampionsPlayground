using System.Collections;
using System.Linq;

public sealed class ResolveVillainBoardWhenRevealedCommand : BaseSingleCommand
{
    private ResolveVillainBoardWhenRevealedCommand(IGame game) : base(game) { }
    private ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            OwnerIdSelector.Get(Game.GetFirst(PlayerTypeSelector.Get(HeroType.Villain)).Id),
            LocationSelector.Get("BATTLEFIELD"));
    public override IEnumerator Execute()
    {
        Game.GetAll(CardSelector).ToList()
            .ForEach(item =>
            {
                if (item.CurrentFace is IWhenRevealedFacade currentFacade)
                    Game.Enqueue(TransactionCommand.Get(Game, currentFacade.WhenRevealed));
            });
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new ResolveVillainBoardWhenRevealedCommand(game);
}