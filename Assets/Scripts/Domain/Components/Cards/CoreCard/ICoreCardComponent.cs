public interface ICoreCardComponent : ICardComponent<ICoreCardComponent>
{
    string CardId { get; }
    string Id { get; }
    string OwnerId { get; }
    int Order { get; }
    void SetOrder(int newOrder);
}
