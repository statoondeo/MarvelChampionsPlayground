public interface ICoreCardComponent : IComponent<ICoreCardComponent>
{
    string CardId { get; }
    string Id { get; }
    string OwnerId { get; }
    string Location { get; }
    int Order { get; }

    bool IsLocation(string location);
    void SetLocation(string newLocation);
    void SetOrder(int newOrder);
    void MoveTo(string location);
}
