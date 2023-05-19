public interface ILocationComponent : ICardComponent<ILocationComponent>
{
    string Location { get; }
    bool IsLocation(string location);
    void SetLocation(string location);
    void MoveTo(string location);
}
