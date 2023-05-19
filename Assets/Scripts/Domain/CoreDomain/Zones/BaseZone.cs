using System;
using System.Collections.Generic;


public abstract class BaseZone : BaseEntity, IZone
{
    protected BaseZone(IGame game, IMediator<IZoneComponent> mediator, ICoreZoneComponentFacade coreZoneFacade) 
        : base(game)
    {
        Mediator = mediator;
        CoreZoneComponentItem = coreZoneFacade;
        Mediator.Register<ICoreZoneComponent>(CoreZoneComponentItem);
    }

    #region IComponent

    public virtual void Init() { }

    #endregion

    #region ICoreZoneComponent

    protected ICoreZoneComponent CoreZoneComponentItem;
    public string Id => CoreZoneComponentItem.Id;
    public string Label => CoreZoneComponentItem.Label;
    public string OwnerId => CoreZoneComponentItem.OwnerId;

    public virtual void Add(ICard item) => CoreZoneComponentItem.Add(item);
    public void Remove(ICard item) => CoreZoneComponentItem.Remove(item);
    public int Count(ISelector<ICard> selector) => CoreZoneComponentItem.Count(selector);
    public bool Contains(ICard item) => CoreZoneComponentItem.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => CoreZoneComponentItem.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => CoreZoneComponentItem.GetAll(selector);
    public ICard GetLast(ISelector<ICard> selector) => CoreZoneComponentItem.GetLast(selector);
    public ICard GetAt(ISelector<ICard> selector, int index) => CoreZoneComponentItem.GetAt(selector, index);

    #endregion

    #region IMediator<IZoneComponent>

    protected IMediator<IZoneComponent> Mediator;
    public void AddListener<U>(Action<IZoneComponent> callback) where U : IZoneComponent => Mediator.AddListener<U>(callback);
    public void Raise<U>() where U : class, IZoneComponent => Mediator.Raise<U>();
    public IEvent<IZoneComponent> GetEventHandler<U>() where U : IZoneComponent => Mediator.GetEventHandler<U>();
    public void Register<U>(IEvent<IZoneComponent> eventHandler) where U : IZoneComponent => Mediator.Register<U>(eventHandler);
    public void Register<U>(U reference) where U : IZoneComponent => Mediator.Register<U>(reference);
    public void RemoveListener<U>(Action<IZoneComponent> callback) where U : IZoneComponent => Mediator.RemoveListener<U>( callback);
    public void UnRegister<U>(U reference) where U : IZoneComponent => Mediator.UnRegister<U>(reference);
    public U GetFacade<U>() where U : IZoneComponent => Mediator.GetFacade<U>();

    #endregion

    #region IZoneHolder

    public IZone Zone => CoreZoneComponentItem.Zone;
    public virtual void SetZone(IZone zone) => CoreZoneComponentItem.SetZone(zone);

    #endregion
}