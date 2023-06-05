public sealed class CoreCardComponent : BaseCardComponent<ICoreCardComponent>, ICoreCardComponent
{
    public static ICoreCardComponent Get(string cardId, string id, string ownerId)
        => new CoreCardComponent(cardId, id, ownerId);
    public CoreCardComponent(string cardId, string id, string ownerId)
        : base()
    {
        CardId = cardId;
        Id = id;
        OwnerId = ownerId;
        Order = 0;
    }
    private int _Order;
    public int Order
    {
        get => _Order;
        private set
        {
            if (_Order == value) return;
            _Order = value;
            Card?.Raise<ICoreCardComponent>();
        }
    }
    public string CardId { get; private set; }
    public string Id { get; private set; }
    public string OwnerId { get; private set; }
    public void SetOrder(int newOrder) => Order = newOrder;
}
