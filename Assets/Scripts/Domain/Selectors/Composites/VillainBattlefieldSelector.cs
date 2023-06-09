﻿using System.Linq;

public sealed class VillainBattlefieldSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private VillainBattlefieldSelector(IGame game) 
        => Selector = AndCompositeSelector.Get(
                    OwnerIdSelector.Get(game.GetFirst(PlayerTypeSelector.Get(HeroType.Villain)).Id),
                    LocationSelector.Get("BATTLEFIELD"));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(IGame game) => new VillainBattlefieldSelector(game);
}
