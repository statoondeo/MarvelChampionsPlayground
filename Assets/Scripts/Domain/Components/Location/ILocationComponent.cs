public interface ILocationComponent : IComponent<ILocationComponent>
{
    string Location { get; }
    bool IsLocation(string location);
    void SetLocation(string location);
    void MoveTo(string location);
}
