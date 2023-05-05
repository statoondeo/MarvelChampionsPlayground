public interface ICoreCardComponent : IComponent<ICoreCardComponent>
{
    string CardId { get; }
    string Id { get; }
    string OwnerId { get; }
    int Order { get; }
    void SetOrder(int newOrder);
}
