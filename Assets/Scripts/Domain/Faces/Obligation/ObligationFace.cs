public sealed class ObligationFace : BaseFace, IObligationFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
    }

    #endregion

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void AddDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private ObligationFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IBoostFacade boostFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        BoostItem = boostFacade;

        Mediator.Register<IBoostComponent>(BoostItem);
    }

    #endregion

    #region Factory

    public static IObligationFace Get(IMediator<IComponent> mediator, ObligationFaceModel faceModel)
        => new ObligationFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost));

    #endregion
}
