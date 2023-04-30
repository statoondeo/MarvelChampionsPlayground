public sealed class CoreCardComponent : BaseComponent<ICoreCardComponent>, ICoreCardComponent
{
    public static ICoreCardComponent Get(string cardId, string id, string ownerId, IGame game)
        => new CoreCardComponent(cardId, id, ownerId, game);
    public CoreCardComponent(string cardId, string id, string ownerId, IGame game)
        : base()
    {
        CardId = cardId;
        Id = id;
        OwnerId = ownerId;
        Location = string.Empty;
        Order = 0;
        Game = game;
    }

    public string CardId { get; private set; }
    public string Id { get; private set; }
    public string OwnerId { get; private set; }
    public string Location { get; private set; }
    public int Order { get; private set; }
    public IGame Game { get; private set; }
    public bool IsLocation(string location) => Location.Equals(location);
    public void MoveTo(string location) => Location = location;
    public void SetLocation(string newLocation) => Location = newLocation;
    public void SetOrder(int newOrder) => Order = newOrder;
}
