using System;

public abstract class BaseCard : ICard
{
    protected BaseCard(
            ICoreCardFacade cardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade
            )
    {
        CardItem = cardFacade;
        FlipItem = flipFacade;
        TapItem = tapFacade;
    }

    #region ICardType

    public CardType CardType => FlipItem.CurrentFace.CardType;
    public bool IsCardType(CardType cardType)
    {
        foreach (ICoreFacade face in FlipItem.Faces.Get())
            if (face.IsCardType(cardType)) return true;
        return false;
    }

    #endregion

    #region IsClassification

    public Classification Classification => FlipItem.CurrentFace.Classification;
    public bool IsClassification(Classification classification)
    {
        foreach (ICoreFacade face in FlipItem.Faces.Get())
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region IFlipFacade

    private readonly IFlipFacade FlipItem;
    public void AddDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.RemoveDecorator(decorator);
    public void Register(Action<IFlipComponent> callback) => FlipItem.Register(callback);
    public void UnRegister(Action<IFlipComponent> callback) => FlipItem.UnRegister(callback);
    public void Notify(IFlipComponent data) => FlipItem.Notify(data);

    public ICoreFacade CurrentFace => FlipItem.CurrentFace;
    public IRepository<string, ICoreFacade> Faces => FlipItem.Faces;
    public void FlipTo(string face) => FlipItem.FlipTo(face);

    #endregion

    #region ITapFacade

    private readonly ITapFacade TapItem;
    public void AddDecorator(IDecorator<ITapComponent> decorator) 
        => TapItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITapComponent> decorator) 
        => TapItem.RemoveDecorator(decorator);
    public void Register(Action<ITapComponent> callback) => TapItem.Register(callback);
    public void UnRegister(Action<ITapComponent> callback) => TapItem.UnRegister(callback);
    public void Notify(ITapComponent data) => TapItem.Notify(data);

    public bool Tapped => TapItem.Tapped;
    public void Tap() => TapItem.Tap();
    public void UnTap() => TapItem.UnTap();

    #endregion

    #region ICardFacade

    private readonly ICoreCardFacade CardItem;
    public void AddDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.RemoveDecorator(decorator);
    public void Register(Action<ICoreCardComponent> callback) => CardItem.Register(callback);
    public void UnRegister(Action<ICoreCardComponent> callback) => CardItem.UnRegister(callback);
    public void Notify(ICoreCardComponent data) => CardItem.Notify(data);

    public string CardId => CardItem.CardId;
    public string Id => CardItem.Id;
    public string OwnerId => CardItem.OwnerId;
    public string Location => CardItem.Location;
    public int Order => CardItem.Order;

    public bool IsLocation(string location) => CardItem.IsLocation(location);
    public void SetLocation(string newLocation) => CardItem.SetLocation(newLocation);
    public void SetOrder(int newOrder) => CardItem.SetOrder(newOrder);
    public void MoveTo(string location) => CardItem.MoveTo(location);

    #endregion
}
