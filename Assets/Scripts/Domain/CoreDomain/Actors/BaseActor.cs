using System;

public abstract class BaseActor : BaseEntity, IActor
{
    #region ICoreActorComponent

    private readonly ICoreActorComponent CoreActorComponentItem;
    public string Id => CoreActorComponentItem.Id;
    public string Title => CoreActorComponentItem.Id;
    public IHeroCard HeroCard => CoreActorComponentItem.HeroCard;
    public HeroType HeroType => CoreActorComponentItem.HeroType;
    public void SetHeroCard(IHeroCard heroCard) => CoreActorComponentItem.SetHeroCard(heroCard);
    public string GetZoneId(string zoneName) => CoreActorComponentItem.GetZoneId(zoneName);
    public IZone GetZone(string zoneName) => CoreActorComponentItem.GetZone(zoneName);
    public void RegisterZoneId(string zoneName, string zoneId) => CoreActorComponentItem.RegisterZoneId(zoneName, zoneId);

    #endregion

    #region Constructor

    protected BaseActor(IGame game, IMediator<IActorComponent> mediator, ICoreActorComponent coreActorComponentItem) : base(game)
    {
        Mediator = mediator;
        CoreActorComponentItem = coreActorComponentItem;
    }

    #endregion

    #region IActorHolder

    public IActor Actor => CoreActorComponentItem.Actor;
    public virtual void SetActor(IActor actor) => CoreActorComponentItem.SetActor(actor);

    #endregion

    #region IComponent

    public virtual void Init() { }

    #endregion

    #region IMediator<IActorComponent>

    protected readonly IMediator<IActorComponent> Mediator;
    public void AddListener<U>(Action<IActorComponent> callback) where U : IActorComponent => Mediator.AddListener<U>(callback);
    public void Raise<U>() where U : class, IActorComponent => Mediator.Raise<U>();
    public IEvent<IActorComponent> GetEventHandler<U>() where U : IActorComponent => Mediator.GetEventHandler<U>();
    public void Register<U>(IEvent<IActorComponent> eventHandler) where U : IActorComponent => Mediator.Register<U>(eventHandler);
    public void Register<U>(U reference) where U : IActorComponent => Mediator.Register<U>(reference);
    public void RemoveListener<U>(Action<IActorComponent> callback) where U : IActorComponent => Mediator.RemoveListener<U>(callback);
    public void UnRegister<U>(U reference) where U : IActorComponent => Mediator.UnRegister<U>(reference);
    public U GetFacade<U>() where U : IActorComponent => Mediator.GetFacade<U>();

    #endregion
}
