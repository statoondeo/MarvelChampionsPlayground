public sealed class BasicTreacheryFace : BaseFace, ITreacheryFace
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

    private BasicTreacheryFace(
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

    public static ITreacheryFace Get(TreacheryFaceModel faceModel)
        => new BasicTreacheryFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            BoostComponent.Get(faceModel.Boost),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}
