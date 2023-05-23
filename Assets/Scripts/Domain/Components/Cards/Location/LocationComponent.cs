public sealed class LocationComponent : BaseCardComponent<ILocationComponent>, ILocationComponent
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
    private LocationComponent(string location) : base() => Location = location;
    public bool IsLocation(string location) 
        => Location.Equals(GetZone(location)?.Id);
    public void MoveTo(string newLocation)
    {
        if (IsLocation(newLocation)) return;
        IZone oldZone = GetZone(Location);
        IZone newZone = GetZone(newLocation);
        newZone.Add(Card);
        oldZone?.Remove(Card);
        SetLocation(newZone.Id);
    }
    private IZone GetZone(string location)
    {
        IZone zone = Card.Game.GetFirst(ZoneIdSelector.Get(location));
        if (zone is not null) return zone;
        return Card.Game.GetFirst(ZoneNameSelector.Get(Card.Game, Card.OwnerId, location));
    }

    public void SetLocation(string newLocation) => Location = newLocation;
    public static ILocationComponent Get(string location)
        => new LocationComponent(location);
}
