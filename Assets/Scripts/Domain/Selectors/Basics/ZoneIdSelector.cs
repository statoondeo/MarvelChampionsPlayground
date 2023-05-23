public sealed class ZoneIdSelector : ISelector<IZone>
{
    private readonly string ZoneId;
    private ZoneIdSelector(string zoneId) => ZoneId = zoneId;
    public bool Match(IZone item) => ZoneId.Equals(item.Id);
    public static ISelector<IZone> Get(string zoneId) => new ZoneIdSelector(zoneId);
}
