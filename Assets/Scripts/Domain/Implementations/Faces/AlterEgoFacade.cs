public sealed class AlterEgoFacade : BaseFacade, IAlterEgoFacade
{
    #region IRecoveryFacade

    private readonly IRecoveryFacade RecoveryItem;
    IRecovery IFacade<IRecovery>.Item => RecoveryItem.Item;
    int IRecovery.Recovery => RecoveryItem.Recovery;
    void IFacade<IRecovery>.AddDecorator(IDecorator<IRecovery> decorator) => RecoveryItem.AddDecorator(decorator);
    void IFacade<IRecovery>.RemoveDecorator(IDecorator<IRecovery> decorator) => RecoveryItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    IHandSize IFacade<IHandSize>.Item => HandSizeItem.Item;
    int IHandSize.HandSize => HandSizeItem.HandSize;
    void IFacade<IHandSize>.AddDecorator(IDecorator<IHandSize> decorator) => HandSizeItem.AddDecorator(decorator);
    void IFacade<IHandSize>.RemoveDecorator(IDecorator<IHandSize> decorator) => HandSizeItem.RemoveDecorator(decorator);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    ISetup IFacade<ISetup>.Item => SetupItem.Item;
    ICommand ISetup.Setup => SetupItem.Setup;
    void IFacade<ISetup>.AddDecorator(IDecorator<ISetup> decorator) => SetupItem.AddDecorator(decorator);
    void IFacade<ISetup>.RemoveDecorator(IDecorator<ISetup> decorator) => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    public AlterEgoFacade(
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

    public static IAlterEgoFacade Get(AlterEgoFaceModel faceModel)
        => new AlterEgoFacade(
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    RecoveryFacade.Get(faceModel.Recovery),
                    HandSizeFacade.Get(faceModel.HandSize),
                    SetupFacade.Get(NullCommand.Get()));

    #endregion
}
//public sealed class BasicAlterEgoFace : BaseFace, IAlterEgoFace
//{
//    #region IRecovery

//    private readonly IRecovery RecoveryBrick;
//    public int Recovery => RecoveryBrick.Recovery;

//    #endregion

//    #region IHandSize

//    private readonly IHandSize HandSizeBrick;
//    public int HandSize => HandSizeBrick.HandSize;

//    #endregion

//    #region ISetup

//    private readonly ISetup SetupBrick;
//    public ICommand Setup => SetupBrick.Setup;

//    #endregion

//    #region Constructeur

//    public BasicAlterEgoFace(
//            ITitle titleComponent,
//            ICardType cardTypeComponent,
//            IClassification classificationComponent,
//            IRecovery recoveryComponent,
//            IHandSize handSizeComponent,
//            ISetup setupComponent)
//        : base(
//            titleComponent,
//            cardTypeComponent,
//            classificationComponent)
//    {
//        RecoveryBrick = recoveryComponent;
//        HandSizeBrick = handSizeComponent;
//        SetupBrick = setupComponent;
//    }

//    #endregion

//    #region Factory

//    public static IAlterEgoFace Get(AlterEgoFaceModel faceModel)
//        => new BasicAlterEgoFace(
//                    TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
//                    CardTypeComponent.Get(faceModel.CardType),
//                    ClassificationComponent.Get(faceModel.Classification),
//                    RecoveryComponent.Get(faceModel.Recovery),
//                    HandSizeComponent.Get(faceModel.HandSize),
//                    SetupComponent.Get(NullCommand.Get()));

//    #endregion
//}