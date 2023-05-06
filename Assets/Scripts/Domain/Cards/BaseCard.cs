using System;
using System.Collections.Generic;

using static UnityEditor.Progress;

public abstract class BaseCard : ICard
{
    public ICard Card => this;
    protected readonly ICardMediator Mediator;
    public IGame Game { get; protected set; }
    public ComponentType Type => ComponentType.Composite;
    protected BaseCard(
        IGame game,
        ICardMediator mediator,
        ICoreCardFacade cardFacade,
        IFlipFacade flipFacade,
        ITapFacade tapFacade,
        ILocationFacade locationFacade)
    {
        CardItem = cardFacade;
        FlipItem = flipFacade;
        TapItem = tapFacade;
        LocationItem = locationFacade;
        Game = game;
        Mediator = mediator;
        SetCard(this);
    }
    public void SetCard(ICard card)
    {
        Mediator.SetCard(card);
        FlipItem.SetCard(card);
        TapItem.SetCard(card);
        LocationItem.SetCard(card);
        CardItem.SetCard(card);
    }

    #region ILocationFacade

    private readonly ILocationFacade LocationItem;
    public void AddDecorator(IDecorator<ILocationComponent> decorator) => LocationItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILocationComponent> decorator) => LocationItem.RemoveDecorator(decorator);
    public string Location => LocationItem.Location;
    public bool IsLocation(string location) => LocationItem.IsLocation(location);
    public void SetLocation(string location) => LocationItem.SetLocation(location);
    public void MoveTo(string location) => LocationItem.MoveTo(location);

    #endregion

    #region ICardType

    public CardType CardType => FlipItem.CurrentFace.CardType;
    public bool IsCardType(CardType cardType)
    {
        foreach (ICoreFacade face in FlipItem.Faces.Values)
            if (face.IsCardType(cardType)) return true;
        return false;
    }

    #endregion

    #region IClassification

    public Classification Classification => FlipItem.CurrentFace.Classification;
    public bool IsClassification(Classification classification)
    {
        foreach (ICoreFacade face in FlipItem.Faces.Values)
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region IFlipFacade

    private readonly IFlipFacade FlipItem;
    public void AddDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.RemoveDecorator(decorator);
    public IFace CurrentFace => FlipItem.CurrentFace;
    public IDictionary<string, IFace> Faces => FlipItem.Faces;
    public void FlipTo(string face) => FlipItem.FlipTo(face);
    public bool IsFace(string face) => FlipItem.IsFace(face);

    #endregion

    #region ITapFacade

    private readonly ITapFacade TapItem;
    public void AddDecorator(IDecorator<ITapComponent> decorator)
        => TapItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITapComponent> decorator)
        => TapItem.RemoveDecorator(decorator);
    public bool Tapped => TapItem.Tapped;
    public void Tap() => TapItem.Tap();
    public void UnTap() => TapItem.UnTap();

    #endregion

    #region ICardFacade

    private readonly ICoreCardFacade CardItem;
    public void AddDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICoreCardComponent> decorator) => CardItem.RemoveDecorator(decorator);
    public string CardId => CardItem.CardId;
    public string Id => CardItem.Id;
    public string OwnerId => CardItem.OwnerId;
    public int Order => CardItem.Order;
    public void SetOrder(int newOrder) => CardItem.SetOrder(newOrder);

    #endregion

    #region IMediator<CardEvent, ICard>

    public void Raise(ComponentType eventName) => Mediator.Raise(eventName);
    public void Raise(ComponentType eventName, ICard eventArg) => Mediator.Raise(eventName, eventArg);
    public void Register(ComponentType eventToListen, Action<ICard> callback) => Mediator.Register(eventToListen, callback);
    public void UnRegister(ComponentType eventToListen, Action<ICard> callback) => Mediator.UnRegister(eventToListen, callback);

    #endregion
}
