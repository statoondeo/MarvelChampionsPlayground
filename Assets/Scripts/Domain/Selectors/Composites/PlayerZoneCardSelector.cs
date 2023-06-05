
public sealed class PlayerZoneCardSelector : ISelector<ICard>
{
    private readonly ISelector<ICard> Selector;
    private PlayerZoneCardSelector(string ownerId, string location)
        => Selector =
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(ownerId),
                LocationSelector.Get(location));
    public bool Match(ICard card) => Selector.Match(card);
    public static ISelector<ICard> Get(string ownerId, string location) => new PlayerZoneCardSelector(ownerId, location);
}
