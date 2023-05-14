
public sealed class ZoneNameSelector : ISelector<IZone>
{
    private readonly ISelector<IZone> Selector;
    private ZoneNameSelector(IGame game, string ownerId, string zoneName) 
        => Selector = ZoneIdSelector.Get(game.GetFirst(PlayerIdSelector.Get(ownerId)).GetZoneId(zoneName));

    public bool Match(IZone item) => Selector.Match(item);
    public static ISelector<IZone> Get(IGame game, string ownerId, string zoneName) 
        => new ZoneNameSelector(game, ownerId, zoneName);
}