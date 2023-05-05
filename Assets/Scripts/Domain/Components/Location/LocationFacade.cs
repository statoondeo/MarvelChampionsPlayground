public sealed class LocationFacade : BaseFacade<ILocationComponent>, ILocationFacade
{
    private LocationFacade(ILocationComponent item)
        : base(item) { }
    public string Location => Item.Location;

    public static ILocationFacade Get(string location)
        => new LocationFacade(LocationComponent.Get(location));

    public bool IsLocation(string location) => Item.IsLocation(location);
    public void MoveTo(string location) => Item.MoveTo(location);
    public void SetLocation(string location) => Item.SetLocation(location);
}