using System.Collections.Generic;

public sealed class PlayerObligationSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerObligationSelector(string ownerId)
        => Selector = 
            AndCompositeSelector.Get(
                    OwnerIdSelector.Get(ownerId),
                    CardTypeSelector.Get(CardType.Obligation));
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards) => Selector.Select(cards);
    public static ISelector<ICard> Get(string ownerId) => new PlayerObligationSelector(ownerId);
}
