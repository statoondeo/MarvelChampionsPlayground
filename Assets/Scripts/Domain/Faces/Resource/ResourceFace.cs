public sealed class ResourceFace : BaseFace, IResourceFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        ResourceItem.SetCard(card);
    }

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;

    public int Energy => ResourceItem.Energy;
    public int Mental => ResourceItem.Mental;
    public int Physic => ResourceItem.Physic;
    public int Wild => ResourceItem.Wild;

    public void AddDecorator(IDecorator<IResourceGeneratorComponent> decorator)
        => ResourceItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator)
        => ResourceItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private ResourceFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IResourceGeneratorFacade resourceFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade) 
        => ResourceItem = resourceFacade;

    #endregion

    #region Factory

    public static IResourceFace Get(ResourceFaceModel faceModel)
        => new ResourceFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild));

    #endregion
}
