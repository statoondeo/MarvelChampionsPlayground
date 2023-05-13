using System;

using UnityEngine;

public abstract class BaseFace : IFace, ICoreFacade
{
    #region IComponent

    public virtual void Init() 
    {
        CardTypeFacade.Init();
        ClassificationFacade.Init();
        TitleFacade.Init();
    }

    #endregion

    #region ICardHolder

    public ICard Card { get; private set; }
    public virtual void SetCard(ICard card) 
    {
        Card = card;
        CardTypeFacade.SetCard(card);
        ClassificationFacade.SetCard(card);
        TitleFacade.SetCard(card);
    }

    #endregion

    #region Constructeur

    protected BaseFace(IMediator<IComponent> mediator, ITitleFacade titleFacade, ICardTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
    {
        Mediator = mediator;
        TitleFacade = titleFacade;
        CardTypeFacade = cardTypeFacade;
        ClassificationFacade = classificationFacade;

        Mediator.Register<ITitleComponent>(TitleFacade);
        Mediator.Register<ICardTypeComponent>(CardTypeFacade);
        Mediator.Register<IClassificationComponent>(ClassificationFacade);
    }

    #endregion

    #region ICardTypeFacade

    private readonly ICardTypeFacade CardTypeFacade;

    public void AddDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICardTypeComponent> decorator) 
        => CardTypeFacade.RemoveDecorator(decorator);

    public CardType CardType => CardTypeFacade.CardType;
    public bool IsCardType(CardType cardType)
        => CardTypeFacade.IsCardType(cardType);

    #endregion

    #region IClassificationFacade

    private readonly IClassificationFacade ClassificationFacade;

    public void AddDecorator(IDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.RemoveDecorator(decorator);

    public Classification Classification => ClassificationFacade.Classification;
    public bool IsClassification(Classification classification)
        => ClassificationFacade.IsClassification(classification);

    #endregion

    #region ITitleFacade

    private readonly ITitleFacade TitleFacade;
    public void AddDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITitleComponent> decorator) 
        => TitleFacade.RemoveDecorator(decorator);

    public string Title => TitleFacade.Title;
    public string SubTitle => TitleFacade.SubTitle;
    public Sprite Sprite => TitleFacade.Sprite;

    #endregion

    #region IMediator<IComponent>

    protected readonly IMediator<IComponent> Mediator;
    public void AddListener<U>(Action<IComponent> callback) where U : IComponent => Mediator.AddListener<U>(callback);
    public void RemoveListener<U>(Action<IComponent> callback) where U : IComponent => Mediator.RemoveListener<U>(callback);
    public void Raise<U>() where U : class, IComponent => Mediator.Raise<U>();
    public U GetFacade<U>() where U : IComponent => Mediator.GetFacade<U>();
    public void Register<U>(U reference) where U : IComponent => Mediator.Register<U>(reference);
    public void UnRegister<U>(U reference) where U : IComponent => Mediator.UnRegister<U>(reference);
    public IEvent<IComponent> GetEventHandler<U>() where U : IComponent => Mediator.GetEventHandler<U>();
    public void Register<U>(IEvent<IComponent> eventHandler) where U : IComponent => Mediator.Register<U>(eventHandler);

    #endregion
}