using System.Collections.Generic;

public sealed class CoreZoneComponentFacade : BaseZoneComponentFacade<ICoreZoneComponent>, ICoreZoneComponentFacade
{
    #region Constructor

    private CoreZoneComponentFacade(ICoreZoneComponent item) 
        : base(item) { }

    #endregion

    #region ICoreZoneComponent

    public string Id => Item.Id;
    public string Label => Item.Id;
    public string OwnerId => Item.Id;

    public void Add(ICard item) => Item.Add(item);
    public void Remove(ICard item) => Item.Remove(item);
    public int Count(ISelector<ICard> selector) => Item.Count(selector);
    public bool Contains(ICard item) => Item.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => Item.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => Item.GetAll(selector);
    public ICard GetLast(ISelector<ICard> selector) => Item.GetLast(selector);
    public ICard GetAt(ISelector<ICard> selector, int index) => Item.GetAt(selector, index);

    #endregion

    #region Factory

    public static ICoreZoneComponentFacade Get(string id, string label, string ownerId, IRepository<ICard> cardRepository)
        => new CoreZoneComponentFacade(CoreZoneComponent.Get(id, label, ownerId, cardRepository));

    #endregion
}
