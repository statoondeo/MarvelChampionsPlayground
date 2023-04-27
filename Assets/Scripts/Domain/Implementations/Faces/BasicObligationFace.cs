public sealed class BasicObligationFace : BaseFace, IObligationFace
{
    #region IBoost

    private readonly IBoost BoostBrick;
    public int Boost => BoostBrick.Boost;

    #endregion

    #region Constructeur

    private BasicObligationFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IBoost boostComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
        => BoostBrick = boostComponent;

    #endregion

    #region Factory

    public static IObligationFace Get(ObligationFaceModel faceModel)
        => new BasicObligationFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            BoostComponent.Get(faceModel.Boost));

    #endregion
}
