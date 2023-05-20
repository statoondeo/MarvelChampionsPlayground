public sealed class CoreActorComponentFacade : BaseActorComponentFacade<ICoreActorComponent>, ICoreActorComponentFacade
{
    #region Constructor

    private CoreActorComponentFacade(ICoreActorComponent item)
        : base(item) { }

    #endregion

    #region ICoreActorComponent

    public string Id => Item.Id;
    public string Title => Item.Title;
    public HeroType HeroType => Item.HeroType;
    public IHeroCard HeroCard => Item.HeroCard;
    public void SetHeroCard(IHeroCard heroCard) => Item.SetHeroCard(heroCard);
    public string GetZoneId(string zoneName) => Item.GetZoneId(zoneName);
    public IZone GetZone(string zoneName) => Item.GetZone(zoneName);
    public void RegisterZoneId(string zoneName, string zoneId) => Item.RegisterZoneId(zoneName, zoneId);

    #endregion

    #region Factory

    public static ICoreActorComponentFacade Get(string id, string title, HeroType heroType)
        => new CoreActorComponentFacade(CoreActorComponent.Get(id, title, heroType));

    #endregion
}
