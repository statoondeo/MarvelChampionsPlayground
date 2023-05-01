public sealed class LocationSelector : ISelector<ICard>
{
    private readonly string Location;
    private LocationSelector(string location) => Location = location;
    public bool Match(ICard card) => card.IsLocation(Location);
    public static ISelector<ICard> Get(string location) => new LocationSelector(location);
}
