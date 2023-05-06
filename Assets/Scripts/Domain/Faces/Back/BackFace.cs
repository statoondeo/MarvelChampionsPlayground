public sealed class BackFace : BaseFace, IBackFace
{
    #region Constructeur

    private BackFace(ITitleFacade titleFacade, ICardTypeFacade cardTypeFacade, IClassificationFacade classificationFacade)
        : base(titleFacade, cardTypeFacade, classificationFacade) { }

    #endregion

    #region Factory

    public static IFace Get(BackFaceModel faceModel)
        => new BackFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification));

    #endregion
}
