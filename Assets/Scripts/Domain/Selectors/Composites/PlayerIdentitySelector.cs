
public sealed class PlayerIdentitySelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerIdentitySelector(string ownerId)
        => Selector =
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(ownerId),
                CardTypeSelector.Get(CardType.Hero));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(string ownerId) => new PlayerIdentitySelector(ownerId);
}
