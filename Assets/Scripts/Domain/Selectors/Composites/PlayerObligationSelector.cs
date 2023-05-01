public sealed class PlayerObligationSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerObligationSelector(string ownerId)
        => Selector = 
            AndCompositeSelector.Get(
                    OwnerIdSelector.Get(ownerId),
                    CardTypeSelector.Get(CardType.Obligation));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(string ownerId) => new PlayerObligationSelector(ownerId);
}
