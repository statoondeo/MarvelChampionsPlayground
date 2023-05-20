public interface ICoreActorComponent : IActorComponent<ICoreActorComponent>
{
    string Id { get; }
    string Title { get; }
    HeroType HeroType { get; }
    IHeroCard HeroCard { get; }
    void SetHeroCard(IHeroCard heroCard);
    string GetZoneId(string zoneName);
    IZone GetZone(string zoneName);
    void RegisterZoneId(string zoneName, string zoneId);
}
