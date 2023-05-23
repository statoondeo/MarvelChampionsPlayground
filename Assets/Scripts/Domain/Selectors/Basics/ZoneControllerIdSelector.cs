public sealed class ZoneControllerIdSelector : ISelector<BaseZoneController>
{
    private readonly string ZoneId;
    private ZoneControllerIdSelector(string zoneId) => ZoneId = zoneId;
    public bool Match(BaseZoneController item) => ZoneId.Equals(item.Id);
    public static ISelector<BaseZoneController> Get(string zoneId) => new ZoneControllerIdSelector(zoneId);
}