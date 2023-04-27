public sealed class BasicBackFace : BaseFace
{
    #region Constructeur

    private BasicBackFace(ITitle titleComponent, ICardType cardTypeComponent, IClassification classificationComponent) 
        : base(titleComponent, cardTypeComponent, classificationComponent)
    {
    }

    #endregion

    #region Factory

    public static IFace Get(BackFaceModel faceModel)
        => new BasicBackFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification));

    #endregion
}
