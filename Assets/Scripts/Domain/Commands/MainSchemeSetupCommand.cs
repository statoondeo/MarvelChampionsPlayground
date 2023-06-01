using System.Collections;
using System.Linq;

public sealed class MainSchemeSetupCommand : BaseSingleCommand
{
    private MainSchemeSetupCommand(IGame game) : base(game) { }
    private ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            CardTypeSelector.Get(CardType.MainScheme),
            LocationSelector.Get("BATTLEFIELD"));
    public override IEnumerator Execute()
    {
        Game.GetAll(CardSelector).ToList()
            .ForEach(item =>
            {
                if (item is ISetupFacade itemFacade)
                    Game.Enqueue(itemFacade.Setup);
            });
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new MainSchemeSetupCommand(game);
}
