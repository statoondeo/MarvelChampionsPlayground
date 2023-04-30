using System;

public sealed class CoreCardFacade : ICoreCardFacade
{
    private readonly IFacade<ICoreCardComponent> Facade;
    private CoreCardFacade(ICoreCardComponent item) => Facade = FacadeComponent<ICoreCardComponent>.Get(item);

    #region IFacade<ICoreCard>

    public ICoreCardComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ICoreCardComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICoreCardComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ICoreCard

    public string CardId => Item.CardId;
    public string Id => Item.Id;
    public string OwnerId => Item.OwnerId;
    public string Location => Item.Location;
    public int Order => Item.Order;

    public Action<ICoreCardComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }

    public bool IsLocation(string location) => Item.IsLocation(location);
    public void MoveTo(string location) => Item.MoveTo(location);
    public void SetLocation(string newLocation) => Item.SetLocation(newLocation);
    public void SetOrder(int newOrder) => Item.SetOrder(newOrder);

    #endregion

    public static ICoreCardFacade Get(string cardId, string id, string ownerId, IGame game) 
        => new CoreCardFacade(CoreCardComponent.Get(cardId, id, ownerId, game));
}