public sealed class NoFilterZoneSelector : ISelector<IZone>
{
    private NoFilterZoneSelector() { }
    public bool Match(IZone item) => true;
    public static ISelector<IZone> Get() => new NoFilterZoneSelector();
}
