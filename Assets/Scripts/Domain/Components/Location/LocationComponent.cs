public sealed class LocationComponent : BaseComponent<ILocationComponent>, ILocationComponent
{
    private string _Location;
    public string Location
    {
        get => _Location;
        private set
        {
            if (_Location == value) return;
            _Location = value;
            Card?.Raise<ILocationComponent>();
        }
    }
    private LocationComponent(string location) : base()
    {
        Type = ComponentType.Location;
        Location = location;
    }
    public bool IsLocation(string location) => Location.Equals(location);
    public void MoveTo(string location)
    {
        SetLocation(location);
        //Card.Game.GetFirst(ZoneNameSelector.Get(Card.Game.GetFirst(PlayerIdSelector.Get(Card.OwnerId)), location)).Add(Card);
    }

    public void SetLocation(string newLocation) => Location = newLocation;
    public static ILocationComponent Get(string location)
        => new LocationComponent(location);
}
