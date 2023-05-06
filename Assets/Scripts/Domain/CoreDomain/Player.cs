using System.Collections.Generic;

public sealed class Player : BaseEntity, IPlayer
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public IHeroCard HeroCard { get; private set; }
    public HeroType HeroType { get; private set; }
    private readonly IDictionary<string, string> ZoneAtlas;

    public Player(IGame game, string id, string title, HeroType heroType) : base(game)
    {
        Id = id;
        Title = title;
        ZoneAtlas = new Dictionary<string, string>();
        HeroType = heroType;
    }
    public string GetZoneId(string zoneName)
    {
        if (ZoneAtlas.TryGetValue(zoneName, out string zoneId)) return zoneId;
        return string.Empty;
    }
    public IZone GetZone(string zoneName) => Game.GetFirst(ZoneIdSelector.Get(GetZoneId(zoneName)));
    public void RegisterZoneId(string zoneName, string zoneId) => ZoneAtlas.Add(zoneName, zoneId);

    public void Draw(int nb) { }
    public void SetHeroCard(IHeroCard heroCard) => HeroCard = heroCard;
}
