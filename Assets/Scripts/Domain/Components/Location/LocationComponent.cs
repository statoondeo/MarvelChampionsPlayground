
using UnityEngine;

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
    private LocationComponent(string location) : base() => Location = location;
    public bool IsLocation(string location)
    {
        string newLocationId = Card.Game.GetFirst(ZoneNameSelector.Get(Card.Game.GetFirst(PlayerIdSelector.Get(Card.OwnerId)), location))?.Id;
        return Location.Equals(newLocationId);
    }
    public void MoveTo(string location)
    {
        if (Card.IsLocation(location)) return;
        Card.Game.GetFirst(ZoneNameSelector.Get(Card.Game.GetFirst(PlayerIdSelector.Get(Card.OwnerId)), location)).Add(Card);
    }

    public void SetLocation(string newLocation) => Location = newLocation;
    public static ILocationComponent Get(string location)
        => new LocationComponent(location);
}
