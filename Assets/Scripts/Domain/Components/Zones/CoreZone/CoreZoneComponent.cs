using System.Collections.Generic;

public sealed class CoreZoneComponent : BaseZoneComponent<ICoreZoneComponent>, ICoreZoneComponent
{
    private CoreZoneComponent(string id, string label, string ownerId, IRepository<ICard> cardRepository) : base()
    {
        Id = id;
        Label = label;
        OwnerId = ownerId;
        CardsItem = cardRepository;
    }
    public string Id { get; private set; }
    public string Label { get; private set; }
    public string OwnerId { get; private set; }

    #region IRepository<ICard>

    private IRepository<ICard> CardsItem;

    public void Add(ICard item)
    {
        if (CardsItem.Contains(item)) return;
        item.SetOrder(CardsItem.Count(NoFilterCardSelector.Get()));
        CardsItem.Add(item);
        item.SetLocation(Id);
        Zone.Raise<ICoreZoneComponent>();
    }
    public void Remove(ICard item)
    {
        if (!CardsItem.Contains(item)) return;
        CardsItem.Remove(item);
        foreach (ICard card in CardsItem.GetAll(CardOrderAndOverSelector.Get(item.Order))) card.SetOrder(card.Order - 1);
        Zone.Raise<ICoreZoneComponent>();
    }
    public int Count(ISelector<ICard> selector) => CardsItem.Count(selector);
    public bool Contains(ICard item) => CardsItem.Contains(item);
    public ICard GetFirst(ISelector<ICard> selector) => CardsItem.GetFirst(selector);
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => CardsItem.GetAll(selector);
    public ICard GetLast(ISelector<ICard> selector) => CardsItem.GetLast(selector);
    public ICard GetAt(ISelector<ICard> selector, int index) => CardsItem.GetAt(selector, index);

    #endregion

    public static ICoreZoneComponent Get(string id, string label, string ownerId, IRepository<ICard> cardRepository)
        => new CoreZoneComponent(id, label, ownerId, cardRepository);
}
