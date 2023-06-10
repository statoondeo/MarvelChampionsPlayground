public sealed class NotCardSelector : ISelector<ICard>
{
    private readonly string Id;
    private NotCardSelector(string id) => Id = id;
    public bool Match(ICard card) => !card.Id.Equals(Id);
    public static ISelector<ICard> Get(string id) => new NotCardSelector(id);
}

