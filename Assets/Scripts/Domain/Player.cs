public class Player : BaseEntity, IPlayer
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public HeroType HeroType { get; private set; }
    private readonly IRepository<string, string> ZoneAtlas;

    public Player(IGame game, string id, string title, HeroType heroType) : base(game)
    {
        Id = id;
        Title = title;
        ZoneAtlas = new Repository<string, string>();
        HeroType = heroType;
    }
    public string GetZoneId(string zoneName)
    {
        if (ZoneAtlas.TryGetValue(zoneName, out string zoneId)) return zoneId;
        return string.Empty;
    }
    public IZone GetZone(string zoneName) => Game.Zones.Get(GetZoneId(zoneName));
    public string RegisterZoneId(string zoneName, string zoneId) => ZoneAtlas.Register(zoneName, zoneId);
}