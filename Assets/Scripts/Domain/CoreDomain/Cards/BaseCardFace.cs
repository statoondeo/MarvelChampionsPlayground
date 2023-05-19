using System;

using UnityEngine;

public abstract class BaseCardFace : ICardFace, ICoreFaceFacade
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

    protected BaseCardFace(IMediator<ICardComponent> mediator, ITitleFacade titleFacade, IFaceTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
    {
        Mediator = mediator;
        TitleFacade = titleFacade;
        CardTypeFacade = cardTypeFacade;
        ClassificationFacade = classificationFacade;

        Mediator.Register<ITitleComponent>(TitleFacade);
        Mediator.Register<IFaceTypeComponent>(CardTypeFacade);
        Mediator.Register<IClassificationComponent>(ClassificationFacade);
    }

    #endregion

    #region ICardTypeFacade

    private readonly IFaceTypeFacade CardTypeFacade;

    public void AddDecorator(ICardComponentDecorator<IFaceTypeComponent> decorator) 
        => CardTypeFacade.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IFaceTypeComponent> decorator) 
        => CardTypeFacade.RemoveDecorator(decorator);

    public FaceType FaceType => CardTypeFacade.FaceType;
    public bool IsFaceType(FaceType cardType)
        => CardTypeFacade.IsFaceType(cardType);

    #endregion

    #region IClassificationFacade

    private readonly IClassificationFacade ClassificationFacade;

    public void AddDecorator(ICardComponentDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IClassificationComponent> decorator)
        => ClassificationFacade.RemoveDecorator(decorator);

    public Classification Classification => ClassificationFacade.Classification;
    public bool IsClassification(Classification classification)
        => ClassificationFacade.IsClassification(classification);

    #endregion

    #region ITitleFacade

    private readonly ITitleFacade TitleFacade;
    public void AddDecorator(ICardComponentDecorator<ITitleComponent> decorator) 
        => TitleFacade.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ITitleComponent> decorator) 
        => TitleFacade.RemoveDecorator(decorator);

    public string Title => TitleFacade.Title;
    public string SubTitle => TitleFacade.SubTitle;
    public Sprite Sprite => TitleFacade.Sprite;

    #endregion

    #region IMediator<ICardComponent>

    protected readonly IMediator<ICardComponent> Mediator;
    public void AddListener<U>(Action<ICardComponent> callback) where U : ICardComponent => Mediator.AddListener<U>(callback);
    public void RemoveListener<U>(Action<ICardComponent> callback) where U : ICardComponent => Mediator.RemoveListener<U>(callback);
    public void Raise<U>() where U : class, ICardComponent => Mediator.Raise<U>();
    public U GetFacade<U>() where U : ICardComponent => Mediator.GetFacade<U>();
    public void Register<U>(U reference) where U : ICardComponent => Mediator.Register<U>(reference);
    public void UnRegister<U>(U reference) where U : ICardComponent => Mediator.UnRegister<U>(reference);
    public IEvent<ICardComponent> GetEventHandler<U>() where U : ICardComponent => Mediator.GetEventHandler<U>();
    public void Register<U>(IEvent<ICardComponent> eventHandler) where U : ICardComponent => Mediator.Register<U>(eventHandler);

    #endregion
}