using System.Collections;
using System.Linq;

public sealed class HeroSetupCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private HeroSetupCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    private ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            PlayerIdentitySelector.Get(PlayerId),
            LocationSelector.Get("BATTLEFIELD"));
    public override IEnumerator Execute()
    {
        Game.GetAll(CardSelector).ToList().ForEach(
            item =>
            {
                if (item is ISetupFacade itemFacade) Game.Enqueue(itemFacade.Setup);
            });
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string playerId) => new HeroSetupCommand(game, playerId);
}
