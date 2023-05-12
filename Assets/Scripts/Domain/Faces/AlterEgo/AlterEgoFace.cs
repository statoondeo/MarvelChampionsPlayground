﻿public sealed class AlterEgoFace : BaseFace, IAlterEgoFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        RecoveryItem.SetCard(card);
        HandSizeItem.SetCard(card);
        SetupItem.SetCard(card);
    }

    #endregion

    #region IRecoveryFacade

    private readonly IRecoveryFacade RecoveryItem;
    public int Recovery => RecoveryItem.Recovery;
    public void AddDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    public int HandSize => HandSizeItem.HandSize;
    public void AddDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.RemoveDecorator(decorator);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;
    public void AddDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    public AlterEgoFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IRecoveryFacade recoveryFacade,
            IHandSizeFacade handSizeFacade,
            ISetupFacade setupFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        RecoveryItem = recoveryFacade;
        HandSizeItem = handSizeFacade;
        SetupItem = setupFacade;

        Mediator.Register<IRecoveryComponent>(RecoveryItem);
        Mediator.Register<IHandSizeComponent>(HandSizeItem);
        Mediator.Register<ISetupComponent>(SetupItem);
    }

    #endregion

    #region Factory

    public static IAlterEgoFace Get(IMediator<IComponent> mediator, AlterEgoFaceModel faceModel)
        => new AlterEgoFace(
                    mediator,
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    RecoveryFacade.Get(faceModel.Recovery),
                    HandSizeFacade.Get(faceModel.HandSize),
                    SetupFacade.Get(NullCommand.Get()));

    #endregion
}
