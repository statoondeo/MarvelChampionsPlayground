public sealed class BasicEnvironmentFace : BaseFace, IEnvironmentFace
{
    #region IBoost

    private IBoost BoostBrick;
    public int Boost => BoostBrick.Boost;

    #endregion

    #region IWhenRevealed

    private readonly IWhenRevealed WhenRevealedBrick;
    public ICommand WhenRevealed => WhenRevealedBrick.WhenRevealed;

    #endregion

    #region Constructeur

    private BasicEnvironmentFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IBoost boostComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        BoostBrick = boostComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static IEnvironmentFace Get(EnvironmentFaceModel faceModel)
        => new BasicEnvironmentFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            BoostComponent.Get(faceModel.Boost),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}