public sealed class LocationComponent : BaseComponent<ILocationComponent>, ILocationComponent
{
    public string Location { get; private set; }
    private LocationComponent(string location) : base()
    {
        Type = ComponentType.Location;
        Location = location;
    }
    public bool IsLocation(string location) => Location.Equals(location);
    public void MoveTo(string location) 
        => Card.Game.GetFirst(ZoneNameSelector.Get(Card.Game.GetFirst(PlayerIdSelector.Get(Card.OwnerId)), location)).Add(Card);

    public void SetLocation(string newLocation)
    {
        if (IsLocation(newLocation)) return;
        Location = newLocation;
        Card.Raise(Type);
    }
    public static ILocationComponent Get(string location)
        => new LocationComponent(location);
}
