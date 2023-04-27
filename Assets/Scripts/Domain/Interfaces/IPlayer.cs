public interface IPlayer : IEntity
{
    string Id { get; }
    string Title { get; }
    HeroType HeroType { get; }

    string GetZoneId(string zoneName);
    IZone GetZone(string zoneName);
    string RegisterZoneId(string zoneName, string zoneId);
}
