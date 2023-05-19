public sealed class CoreCardFacade : BaseCardComponentFacade<ICoreCardComponent>, ICoreCardFacade
{
    private CoreCardFacade(ICoreCardComponent item) : base(item) { }
    public string CardId => Item.CardId;
    public string Id => Item.Id;
    public string OwnerId => Item.OwnerId;
    public int Order => Item.Order;
    public void SetOrder(int newOrder) => Item.SetOrder(newOrder);
    public static ICoreCardFacade Get(string cardId, string id, string ownerId) 
        => new CoreCardFacade(CoreCardComponent.Get(cardId, id, ownerId));
}