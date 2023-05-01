public sealed class CoreCardFacade : BaseComponentFacade<ICoreCardComponent>, ICoreCardFacade
{
    private CoreCardFacade(ICoreCardComponent item) : base(item) { }

    #region ICoreCard

    public string CardId => Item.CardId;
    public string Id => Item.Id;
    public string OwnerId => Item.OwnerId;
    public string Location => Item.Location;
    public int Order => Item.Order;

    public bool IsLocation(string location) => Item.IsLocation(location);
    public void MoveTo(string location) => Item.MoveTo(location);
    public void SetLocation(string newLocation) => Item.SetLocation(newLocation);
    public void SetOrder(int newOrder) => Item.SetOrder(newOrder);

    #endregion

    public static ICoreCardFacade Get(string cardId, string id, string ownerId, IGame game) 
        => new CoreCardFacade(CoreCardComponent.Get(cardId, id, ownerId, game));
}