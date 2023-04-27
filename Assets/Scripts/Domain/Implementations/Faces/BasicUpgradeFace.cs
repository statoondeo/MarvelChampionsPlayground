public sealed class BasicUpgradeFace : BaseFace, IUpgradeFace
{
    #region ICost

    private readonly ICost CostBrick;
    public int Cost => CostBrick.Cost;

    #endregion

    #region IResource

    private readonly IResource ResourceBrick;
    public int Energy => ResourceBrick.Energy;
    public int Mental => ResourceBrick.Mental;
    public int Physic => ResourceBrick.Physic;
    public int Wild => ResourceBrick.Wild;

    #endregion

    #region Constructeur

    private BasicUpgradeFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IResource resourceComponent,
            ICost costComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        CostBrick = costComponent;
        ResourceBrick = resourceComponent;
    }

    #endregion

    #region Factory

    public static IUpgradeFace Get(UpgradeFaceModel faceModel)
        => new BasicUpgradeFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            ResourceComponent.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostComponent.Get(faceModel.Cost));

    #endregion
}
