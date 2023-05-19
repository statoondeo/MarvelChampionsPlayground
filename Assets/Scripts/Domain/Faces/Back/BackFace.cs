public sealed class BackFace : BaseCardFace, IBackFace
{
    #region Constructeur

    private BackFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade, 
            IFaceTypeFacade cardTypeFacade, 
            IClassificationFacade classificationFacade)
        : base(
            mediator,
            titleFacade, 
            cardTypeFacade, 
            classificationFacade) { }

    #endregion

    #region Factory

    public static ICardFace Get(IMediator<ICardComponent> mediator, BackFaceModel faceModel)
        => new BackFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification));

    #endregion
}
