public sealed class BasicSideSchemeFace : BaseFace, ISideSchemeFace
{
    #region IBoost

    private IBoost BoostBrick;
    public int Boost => BoostBrick.Boost;

    #endregion

    #region ITreatStart

    private ITreatStart TreatStartBrick;
    public int TreatStart => TreatStartBrick.TreatStart;

    #endregion

    #region IWhenRevealed

    private readonly IWhenRevealed WhenRevealedBrick;
    public ICommand WhenRevealed => WhenRevealedBrick.WhenRevealed;

    #endregion

    #region Constructeur

    private BasicSideSchemeFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            ITreatStart treatStartComponent,
            IBoost boostComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        TreatStartBrick = treatStartComponent;
        BoostBrick = boostComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static ISideSchemeFace Get(SideSchemeFaceModel faceModel)
        => new BasicSideSchemeFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            TreatStartComponent.Get(faceModel.Starting),
            BoostComponent.Get(faceModel.Boost),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}
