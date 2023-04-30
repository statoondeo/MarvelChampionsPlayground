using System.Collections.Generic;

public sealed class PlayerNemesisSetSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerNemesisSetSelector(string ownerId)
        => Selector =
            AndCompositeSelector.Get(
                    OwnerIdSelector.Get(ownerId),
                    ClassificationSelector.Get(Classification.Nemesis));
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards) => Selector.Select(cards);
    public static ISelector<ICard> Get(string ownerId) => new PlayerNemesisSetSelector(ownerId);
}
