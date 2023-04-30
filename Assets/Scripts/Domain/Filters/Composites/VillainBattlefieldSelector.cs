using System.Collections.Generic;
using System.Linq;

public sealed class VillainBattlefieldSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private VillainBattlefieldSelector(IGame game, string ownerId) => Selector = AndCompositeSelector.Get(
                    OwnerIdSelector.Get(PlayerTypeSelector.Get(HeroType.Villain).Select(game.Players.Get()).First().Id),
                    LocationSelector.Get("BATTLEFIELD"));
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards) => Selector.Select(cards);
    public static ISelector<ICard> Get(IGame game, string ownerId) => new VillainBattlefieldSelector(game, ownerId);
}
