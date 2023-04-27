public sealed class BasicResourceFace : BaseFace, IResourceFace
{
    #region IResource

    private readonly IResource ResourceBrick;
    public int Energy => ResourceBrick.Energy;
    public int Mental => ResourceBrick.Mental;
    public int Physic => ResourceBrick.Physic;
    public int Wild => ResourceBrick.Wild;

    #endregion

    #region Constructeur

    private BasicResourceFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IResource resourceComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent) 
        => ResourceBrick = resourceComponent;

    #endregion

    #region Factory

    public static IResourceFace Get(ResourceFaceModel faceModel)
        => new BasicResourceFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            ResourceComponent.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild));

    #endregion
}
