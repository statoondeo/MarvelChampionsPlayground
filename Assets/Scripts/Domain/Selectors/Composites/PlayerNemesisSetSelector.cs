public sealed class PlayerNemesisSetSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerNemesisSetSelector(string ownerId)
        => Selector =
            AndCompositeSelector.Get(
                    OwnerIdSelector.Get(ownerId),
                    ClassificationSelector.Get(Classification.Nemesis));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(string ownerId) => new PlayerNemesisSetSelector(ownerId);
}
