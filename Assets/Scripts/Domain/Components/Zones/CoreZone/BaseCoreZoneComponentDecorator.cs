using System.Collections.Generic;

public abstract class BaseCoreZoneComponentDecorator : BaseZoneComponentDecorator<ICoreZoneComponent>, ICoreZoneComponent
{
    #region ICoreZoneComponent

    private ICoreZoneComponent InnerComponent => Inner as ICoreZoneComponent;
    public virtual string Id => InnerComponent.Id;
    public virtual string Label => InnerComponent.Label;
    public virtual string OwnerId => InnerComponent.OwnerId;

    public virtual void Add(ICard item) => InnerComponent.Add(item);
    public virtual void Remove(ICard item) => InnerComponent.Remove(item);
    public virtual int Count(ISelector<ICard> selector) => InnerComponent.Count(selector);
    public virtual bool Contains(ICard item) => InnerComponent.Contains(item);
    public virtual ICard GetFirst(ISelector<ICard> selector) => InnerComponent.GetFirst(selector);
    public virtual IEnumerable<ICard> GetAll(ISelector<ICard> selector) => InnerComponent.GetAll(selector);
    public virtual ICard GetLast(ISelector<ICard> selector) => InnerComponent.GetLast(selector);
    public virtual ICard GetAt(ISelector<ICard> selector, int index) => InnerComponent.GetAt(selector, index);

    #endregion
}