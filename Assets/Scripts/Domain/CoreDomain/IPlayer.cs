public interface IPlayer : IEntity
{
    string Id { get; }
    string Title { get; }
    HeroType HeroType { get; }
    void Draw(int nb);
    void DrawUpToHand();
    string GetZoneId(string zoneName);
    IZone GetZone(string zoneName);
    void RegisterZoneId(string zoneName, string zoneId);
    IHeroCard HeroCard { get; }
    void SetHeroCard(IHeroCard heroCard);
}
