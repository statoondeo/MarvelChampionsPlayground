
public sealed class VillainIdentitySelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private VillainIdentitySelector(string ownerId)
        => Selector =
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(ownerId),
                CardTypeSelector.Get(CardType.Villain));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(string ownerId) => new VillainIdentitySelector(ownerId);
}
