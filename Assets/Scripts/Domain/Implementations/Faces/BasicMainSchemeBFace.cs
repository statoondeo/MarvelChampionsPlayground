public sealed class BasicMainSchemeBFace : BaseFace, IMainSchemeBFace
{
    #region IStade

    private readonly IStade StadeBrick;
    public int Stade => StadeBrick.Stade;

    #endregion

    #region ITreatThreshold

    private readonly ITreatThreshold TreatThresholdBrick;
    public int TreatThreshold => TreatThresholdBrick.TreatThreshold;

    #endregion

    #region ITreatStart

    private readonly ITreatStart TreatStartBrick;
    public int TreatStart => TreatStartBrick.TreatStart;

    #endregion

    #region ITreatAcceleration

    private readonly ITreatAcceleration TreatAccelerationBrick;
    public int TreatAcceleration => TreatAccelerationBrick.TreatAcceleration;

    #endregion

    #region IWhenRevealed

    private readonly IWhenRevealed WhenRevealedBrick;
    public ICommand WhenRevealed => WhenRevealedBrick.WhenRevealed;

    #endregion

    #region Constructeur

    private BasicMainSchemeBFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IStade stadeComponent,
            ITreatStart treatStartComponent,
            ITreatThreshold treatThresholdComponent,
            ITreatAcceleration treatAccelerationComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        StadeBrick = stadeComponent;
        TreatStartBrick = treatStartComponent;
        TreatThresholdBrick = treatThresholdComponent;
        TreatAccelerationBrick = treatAccelerationComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static IMainSchemeBFace Get(MainSchemeBFaceModel faceModel)
        => new BasicMainSchemeBFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            StadeComponent.Get(faceModel.Stade),
            TreatStartComponent.Get(faceModel.Starting),
            TreatThresholdComponent.Get(faceModel.Threshold),
            TreatAccelerationComponent.Get(faceModel.Stade),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}