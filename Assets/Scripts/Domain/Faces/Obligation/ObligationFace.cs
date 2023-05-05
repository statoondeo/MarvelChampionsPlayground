public sealed class ObligationFace : CoreFacade, IObligationFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
    }

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
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IBoostFacade boostFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
        => BoostItem = boostFacade;

    #endregion

    #region Factory

    public static IObligationFace Get(ObligationFaceModel faceModel)
        => new ObligationFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost));

    #endregion
}
