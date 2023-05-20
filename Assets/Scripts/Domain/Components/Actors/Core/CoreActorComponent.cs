using System.Collections.Generic;

public sealed class CoreActorComponent : BaseActorComponent<ICoreActorComponent>, ICoreActorComponent
{
    private readonly IDictionary<string, string> ZoneAtlas;
    private CoreActorComponent(string id, string title, HeroType heroType) : base()
    {
        ActorHolder = StandardActorHolder.Get();
        Id = id;
        Title = title;
        HeroType = heroType;
        ZoneAtlas = new Dictionary<string, string>();
    }
    public string Id { get; private set; }
    public string Title { get; private set; }
    public HeroType HeroType { get; private set; }
    public IHeroCard HeroCard { get; private set; }
    public void SetHeroCard(IHeroCard heroCard) => HeroCard = heroCard;
    public string GetZoneId(string zoneName)
    {
        if (ZoneAtlas.TryGetValue(zoneName, out string zoneId)) return zoneId;
        return string.Empty;
    }
    public IZone GetZone(string zoneName) => Actor.Game.GetFirst(ZoneIdSelector.Get(GetZoneId(zoneName)));
    public void RegisterZoneId(string zoneName, string zoneId) => ZoneAtlas.Add(zoneName, zoneId);

    public static ICoreActorComponent Get(string id, string title, HeroType heroType) 
        => new CoreActorComponent(id, title, heroType);
}
