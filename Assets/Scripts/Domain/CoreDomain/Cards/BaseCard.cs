using System;
using System.Collections.Generic;

public abstract class BaseCard : ICard
{
    public IGame Game { get; protected set; }
    protected BaseCard(
        IGame game,
        ICardTypeFacade cardTypeFacade,
        IMediator<ICardComponent> faceMediator,
        IMediator<ICardComponent> backMediator,
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

    #region ICardComponent

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
    public void AddDecorator(ICardComponentDecorator<ILocationComponent> decorator) => LocationItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ILocationComponent> decorator) => LocationItem.RemoveDecorator(decorator);
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
        foreach (ICoreFaceFacade face in FlipItem.Faces)
            if (face.IsClassification(classification)) return true;
        return false;
    }

    #endregion

    #region IFlipFacade

    private readonly IFlipFacade FlipItem;
    public void AddDecorator(ICardComponentDecorator<IFlipComponent> decorator) => FlipItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IFlipComponent> decorator) => FlipItem.RemoveDecorator(decorator);
    public ICardFace CurrentFace => FlipItem.CurrentFace;
    public IList<ICardFace> Faces => FlipItem.Faces;
    public void FlipTo(int face) => FlipItem.FlipTo(face);
    public void FlipToNext() => FlipItem.FlipToNext();
    public bool IsFace(int face) => FlipItem.IsFace(face);

    #endregion

    #region ITapFacade

    private readonly ITapFacade TapItem;
    public void AddDecorator(ICardComponentDecorator<ITapComponent> decorator)
        => TapItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ITapComponent> decorator)
        => TapItem.RemoveDecorator(decorator);
    public bool Tapped => TapItem.Tapped;
    public void Tap() => TapItem.Tap();
    public void UnTap() => TapItem.UnTap();

    #endregion

    #region ICardFacade

    private readonly ICoreCardFacade CardItem;
    public void AddDecorator(ICardComponentDecorator<ICoreCardComponent> decorator) => CardItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ICoreCardComponent> decorator) => CardItem.RemoveDecorator(decorator);
    public string CardId => CardItem.CardId;
    public string Id => CardItem.Id;
    public string OwnerId => CardItem.OwnerId;
    public int Order => CardItem.Order;
    public void SetOrder(int newOrder) => CardItem.SetOrder(newOrder);

    #endregion

    #region IMediator<ICardComponent>

    public void AddListener<U>(Action<ICardComponent> callback) where U : ICardComponent => CurrentFace.AddListener<U>(callback);
    public void RemoveListener<U>(Action<ICardComponent> callback) where U : ICardComponent => CurrentFace.RemoveListener<U>(callback);
    public void Raise<U>() where U : class, ICardComponent => CurrentFace.Raise<U>();
    public U GetFacade<U>() where U : ICardComponent => CurrentFace.GetFacade<U>();
    public void Register<U>(U reference) where U : ICardComponent => CurrentFace.Register<U>(reference);
    public void UnRegister<U>(U reference) where U : ICardComponent => CurrentFace.UnRegister<U>(reference);
    public IEvent<ICardComponent> GetEventHandler<U>() where U : ICardComponent => CurrentFace.GetEventHandler<U>();
    public void Register<U>(IEvent<ICardComponent> eventHandler) where U : ICardComponent => CurrentFace.Register<U>(eventHandler);

    #endregion
}
