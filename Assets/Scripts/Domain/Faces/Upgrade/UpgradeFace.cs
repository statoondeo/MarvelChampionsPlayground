public sealed class UpgradeFace : BaseCardFace, IUpgradeFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        CostItem.SetCard(card);
        ResourceItem.SetCard(card);
    }

    #endregion

    #region ICostFacade

    private readonly ICostFacade CostItem;
    public int Cost => CostItem.Cost;
    public void Play() => CostItem.Play();
    public void Resolve() => CostItem.Resolve();
    public void AddDecorator(ICardComponentDecorator<ICostComponent> decorator)
        => CostItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ICostComponent> decorator)
        => CostItem.RemoveDecorator(decorator);

    #endregion

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;

    public int Energy => ResourceItem.Energy;
    public int Mental => ResourceItem.Mental;
    public int Physic => ResourceItem.Physic;
    public int Wild => ResourceItem.Wild;

    public void AddDecorator(ICardComponentDecorator<IResourceGeneratorComponent> decorator)
        => ResourceItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IResourceGeneratorComponent> decorator)
        => ResourceItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private UpgradeFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IResourceGeneratorFacade resourceFacade,
            ICostFacade costFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        CostItem = costFacade;
        ResourceItem = resourceFacade;

        Mediator.Register<ICostComponent>(CostItem);
        Mediator.Register<IResourceGeneratorComponent>(ResourceItem);
    }

    #endregion

    #region Factory

    public static IUpgradeFace Get(IMediator<ICardComponent> mediator, UpgradeFaceModel faceModel)
        => new UpgradeFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostFacade.Get(PermanentCostComponent.Get(faceModel.Cost)));

    #endregion
}
