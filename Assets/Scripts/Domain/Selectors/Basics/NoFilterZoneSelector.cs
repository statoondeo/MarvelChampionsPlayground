public sealed class NoFilterZoneSelector : ISelector<IZone>
{
    private NoFilterZoneSelector() { }
    public bool Match(IZone item) => true;
    private static ISelector<IZone> Selector;
    public static ISelector<IZone> Get() => Selector is null ? Selector = new NoFilterZoneSelector() : Selector;
}
