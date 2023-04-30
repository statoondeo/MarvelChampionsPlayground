using System;

public sealed class AlterEgoFace : BaseFacade, IAlterEgoFace
{
    #region IRecoveryFacade

    private readonly IRecoveryFacade RecoveryItem;
    IRecoveryComponent IFacade<IRecoveryComponent>.Item => RecoveryItem.Item;
    int IRecoveryComponent.Recovery => RecoveryItem.Recovery;
    void IFacade<IRecoveryComponent>.AddDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.AddDecorator(decorator);
    void IFacade<IRecoveryComponent>.RemoveDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.RemoveDecorator(decorator);

    Action<IRecoveryComponent> IComponent<IRecoveryComponent>.OnChanged
    { get => RecoveryItem.OnChanged; set => RecoveryItem.OnChanged = value; }

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    IHandSizeComponent IFacade<IHandSizeComponent>.Item => HandSizeItem.Item;
    int IHandSizeComponent.HandSize => HandSizeItem.HandSize;
    void IFacade<IHandSizeComponent>.AddDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.AddDecorator(decorator);
    void IFacade<IHandSizeComponent>.RemoveDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.RemoveDecorator(decorator);

    Action<IHandSizeComponent> IComponent<IHandSizeComponent>.OnChanged
    { get => HandSizeItem.OnChanged; set => HandSizeItem.OnChanged = value; }

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    ISetupComponent IFacade<ISetupComponent>.Item => SetupItem.Item;
    ICommand ISetupComponent.Setup => SetupItem.Setup;

    Action<ISetupComponent> IComponent<ISetupComponent>.OnChanged 
    { get => SetupItem.OnChanged; set => SetupItem.OnChanged = value; }

    void IFacade<ISetupComponent>.AddDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.AddDecorator(decorator);
    void IFacade<ISetupComponent>.RemoveDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    public AlterEgoFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IRecoveryFacade recoveryFacade,
            IHandSizeFacade handSizeFacade,
            ISetupFacade setupFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        RecoveryItem = recoveryFacade;
        HandSizeItem = handSizeFacade;
        SetupItem = setupFacade;
    }

    #endregion

    #region Factory

    public static IAlterEgoFace Get(AlterEgoFaceModel faceModel)
        => new AlterEgoFace(
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    RecoveryFacade.Get(faceModel.Recovery),
                    HandSizeFacade.Get(faceModel.HandSize),
                    SetupFacade.Get(NullCommand.Get()));

    #endregion
}
