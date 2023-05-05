
public sealed class ZoneNameSelector : ISelector<IZone>
{
    private readonly ISelector<IZone> Selector;
    private ZoneNameSelector(IPlayer player, string zoneName)
        => Selector = ZoneIdSelector.Get(player.GetZoneId(zoneName));
    public bool Match(IZone item) => Selector.Match(item);
    public static ISelector<IZone> Get(IPlayer player, string zoneName) => new ZoneNameSelector(player, zoneName);
}