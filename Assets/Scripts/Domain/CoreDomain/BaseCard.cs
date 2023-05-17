using System;
using System.Collections.Generic;

public abstract class BaseCard : ICard
{
    public IGame Game { get; protected set; }
    protected BaseCard(
        IGame game,
        ICardTypeFacade cardTypeFacade,
        IMediator<IComponent> faceMediator,
        IMediator<IComponent> backMediator,
        ICoreCardFacade cardFacade,
        IFlipFacade flipFacade,
        ITapFacade tapFacade,
        ILocationFacade locationFacade)
    {
        faceMediator.Register<ICardTypeComponent>(cardTypeFacade);
        faceMediator.Register<ICoreCardComponent>(cardFacade);
        faceMediator.Register<IFlipComponent>(flipFacade);
        faceMediator.Register<ITapComponent>(tapFacade);
        faceMediator.Register<ILocationComponent>(locationFacade);

        backMediator.Register<ICardTypeComponent>(faceMediator.GetEventHandler<ICardTypeComponent>());
        backMediator.Register<ICoreCardComponent>(faceMediator.GetEventHandler<ICoreCardComponent>());
        backMediator.Register<IFlipComponent>(faceMediator.GetEventHandler<IFlipComponent>());
        backMediator.Register<ITapComponent>(faceMediator.GetEventHandler<ITapComponent>());
        backMediator.Register<ILocationComponent>(faceMediator.GetEventHandler<ILocationComponent>());

        CardTypeItem = cardTypeFacade;
        CardItem = cardFacade;
        FlipItem = flipFacade;
        TapItem = tapFacade;
        LocationItem = locationFacade;
        Game = game;
        SetCard(this);
    }

    #region IComponent

    public virtual void Init()
    {
        CardItem.Init();
        FlipItem.Init();
        TapItem.Init();
        LocationItem.Init();
    }

    #endregion

    #region ICardHolder

    public ICard Card => this;
    public virtual void SetCard(ICard card)
    {
        FlipItem.SetCard(card);
        TapItem.SetCard(card);
        LocationItem.SetCard(card);
        CardItem.SetCard(card);
    }

    #endregion

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

    private ICardType CardTypeItem;
    public CardType CardType => CardTypeItem.CardType;
    public bool IsCardType(CardType cardType) => CardTypeItem.IsCardType(cardType);

    #endregion

    #region IClassification

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
    public void AddDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IFlipComponent> decorator) => FlipItem.RemoveDecorator(decorator);
    public IFace CurrentFace => FlipItem.CurrentFace;
    public IList<IFace> Faces => FlipItem.Faces;
    public void FlipTo(int face) => FlipItem.FlipTo(face);
    public void FlipToNext() => FlipItem.FlipToNext();
    public bool IsFace(int face) => FlipItem.IsFace(face);

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

    #region IMediator<IComponent>

    public void AddListener<U>(Action<IComponent> callback) where U : IComponent => CurrentFace.AddListener<U>(callback);
    public void RemoveListener<U>(Action<IComponent> callback) where U : IComponent => CurrentFace.RemoveListener<U>(callback);
    public void Raise<U>() where U : class, IComponent => CurrentFace.Raise<U>();
    public U GetFacade<U>() where U : IComponent => CurrentFace.GetFacade<U>();
    public void Register<U>(U reference) where U : IComponent => CurrentFace.Register<U>(reference);
    public void UnRegister<U>(U reference) where U : IComponent => CurrentFace.UnRegister<U>(reference);
    public IEvent<IComponent> GetEventHandler<U>() where U : IComponent => CurrentFace.GetEventHandler<U>();
    public void Register<U>(IEvent<IComponent> eventHandler) where U : IComponent => CurrentFace.Register<U>(eventHandler);

    #endregion
}
