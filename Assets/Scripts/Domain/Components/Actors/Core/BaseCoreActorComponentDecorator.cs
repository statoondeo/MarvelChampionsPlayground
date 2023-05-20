using System.Collections.Generic;

public abstract class BaseCoreActorComponentDecorator : BaseActorComponentDecorator<ICoreActorComponent>, ICoreActorComponent
{
    #region ICoreActorComponent

    private ICoreActorComponent InnerComponent => Inner as ICoreActorComponent;
    public virtual string Id => InnerComponent.Id;
    public virtual string Title => InnerComponent.Title;
    public virtual HeroType HeroType => InnerComponent.HeroType;
    public virtual IHeroCard HeroCard => InnerComponent.HeroCard;
    public virtual void SetHeroCard(IHeroCard heroCard) => InnerComponent.SetHeroCard(heroCard);
    private readonly IDictionary<string, string> ZoneAtlas;
    public virtual string GetZoneId(string zoneName) => InnerComponent.GetZoneId(zoneName);
    public IZone GetZone(string zoneName) => InnerComponent.GetZone(zoneName);
    public void RegisterZoneId(string zoneName, string zoneId) => InnerComponent?.RegisterZoneId(zoneName, zoneId);

    #endregion
}