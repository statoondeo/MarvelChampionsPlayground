public sealed class SideSchemeFace : CoreFacade, ISideSchemeFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        TreatStartItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void AddDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region ITreatStartFacade

    private readonly ITreatStartFacade TreatStartItem;
    public int TreatStart => TreatStartItem.TreatStart;
    public void AddDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private SideSchemeFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ITreatStartFacade treatStartFacade,
            IBoostFacade boostFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        TreatStartItem = treatStartFacade;
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static ISideSchemeFace Get(SideSchemeFaceModel faceModel)
        => new SideSchemeFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            TreatStartFacade.Get(faceModel.Starting),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}
