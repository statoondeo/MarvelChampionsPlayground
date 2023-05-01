public sealed class OwnerIdSelector : ISelector<ICard>
{
    private readonly string OwnerId;
    private OwnerIdSelector(string ownerId) => OwnerId = ownerId;
    public bool Match(ICard card) => card.OwnerId.Equals(OwnerId);
    public static ISelector<ICard> Get(string ownerId) => new OwnerIdSelector(ownerId);
}
