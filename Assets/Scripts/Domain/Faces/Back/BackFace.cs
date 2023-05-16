public sealed class BackFace : BaseFace, IBackFace
{
    #region Constructeur

    private BackFace(
            IMediator<IComponent> mediator,
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

    public static IFace Get(IMediator<IComponent> mediator, BackFaceModel faceModel)
        => new BackFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification));

    #endregion
}
