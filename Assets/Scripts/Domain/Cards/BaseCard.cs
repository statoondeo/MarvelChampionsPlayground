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
        foreach (ICoreFacade face in FlipItem.Faces)
            if (face.IsCardType(cardType)) return true;
        return false;
    }

    #endregion

    #region IsClassification

    public Classification Classification => FlipItem.CurrentFace.Classification;
    public bool IsClassification(Classification classification)
    {
        foreach (ICoreFacade face in FlipItem.Faces)
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region IFlipFacade

    private readonly IFlipFacade FlipItem;
    IFlipComponent IFacade<IFlipComponent>.Item => FlipItem.Item;
    void IFacade<IFlipComponent>.AddDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.AddDecorator(decorator);
    void IFacade<IFlipComponent>.RemoveDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.RemoveDecorator(decorator);
    Action<IFlipComponent> IComponent<IFlipComponent>.OnChanged
    { get => FlipItem.OnChanged; set => FlipItem.OnChanged = value; }

    ICoreFacade IFlipComponent.CurrentFace => FlipItem.CurrentFace;
    IRepository<string, ICoreFacade> IFlipComponent.Faces => FlipItem.Faces;
    void IFlipComponent.FlipTo(string face) => FlipItem.FlipTo(face);

    #endregion

    #region ITapFacade

    private readonly ITapFacade TapItem;
    ITapComponent IFacade<ITapComponent>.Item => TapItem.Item;
    void IFacade<ITapComponent>.AddDecorator(IDecorator<ITapComponent> decorator) 
        => TapItem.AddDecorator(decorator);
    void IFacade<ITapComponent>.RemoveDecorator(IDecorator<ITapComponent> decorator) 
        => TapItem.RemoveDecorator(decorator);
    Action<ITapComponent> IComponent<ITapComponent>.OnChanged
    { get => TapItem.OnChanged; set => TapItem.OnChanged = value; }

    bool ITapComponent.Tapped => TapItem.Tapped;
    void ITapComponent.Tap() => TapItem.Tap();
    void ITapComponent.UnTap() => TapItem.UnTap();

    #endregion

    #region ICardFacade

    private readonly ICoreCardFacade CardItem;
    ICoreCardComponent IFacade<ICoreCardComponent>.Item => CardItem.Item;
    void IFacade<ICoreCardComponent>.AddDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.AddDecorator(decorator);
    void IFacade<ICoreCardComponent>.RemoveDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.RemoveDecorator(decorator);
    Action<ICoreCardComponent> IComponent<ICoreCardComponent>.OnChanged
    { get => CardItem.OnChanged; set => CardItem.OnChanged = value; }

    //public IGame Game => CardItem.Game;
    string ICoreCardComponent.CardId => CardItem.CardId;
    string ICoreCardComponent.Id => CardItem.Id;
    string ICoreCardComponent.OwnerId => CardItem.OwnerId;
    string ICoreCardComponent.Location => CardItem.Location;
    int ICoreCardComponent.Order => CardItem.Order;

    bool ICoreCardComponent.IsLocation(string location) => CardItem.IsLocation(location);
    void ICoreCardComponent.SetLocation(string newLocation) => CardItem.SetLocation(newLocation);
    void ICoreCardComponent.SetOrder(int newOrder) => CardItem.SetOrder(newOrder);
    void ICoreCardComponent.MoveTo(string location) => CardItem.MoveTo(location);

    #endregion
}
