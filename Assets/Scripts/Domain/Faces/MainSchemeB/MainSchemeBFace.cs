public sealed class MainSchemeBFace : BaseFace, IMainSchemeBFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        StadeItem.SetCard(card);
        TreatAccelerationItem.SetCard(card);
        TreatStartItem.SetCard(card);
        TreatThresholdItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);

    #endregion

    #region ITreatThresholdFacade

    private readonly ITreatThresholdFacade TreatThresholdItem;
    public int TreatThreshold => TreatThresholdItem.TreatThreshold;
    public void AddDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.RemoveDecorator(decorator);

    #endregion

    #region ITreatStartFacade

    private readonly ITreatStartFacade TreatStartItem;
    public int TreatStart => TreatStartItem.TreatStart;
    public void AddDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.RemoveDecorator(decorator);

    #endregion

    #region ITreatAccelerationFacade

    private readonly ITreatAccelerationFacade TreatAccelerationItem;
    public int TreatAcceleration => TreatAccelerationItem.TreatAcceleration;
    public void AddDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private MainSchemeBFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IStadeFacade stadeFacade,
            ITreatStartFacade treatStartFacade,
            ITreatThresholdFacade treatThresholdFacade,
            ITreatAccelerationFacade treatAccelerationFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        StadeItem = stadeFacade;
        TreatStartItem = treatStartFacade;
        TreatThresholdItem = treatThresholdFacade;
        TreatAccelerationItem = treatAccelerationFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static IMainSchemeBFace Get(MainSchemeBFaceModel faceModel)
        => new MainSchemeBFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            StadeFacade.Get(faceModel.Stade),
            TreatStartFacade.Get(faceModel.Starting),
            TreatThresholdFacade.Get(faceModel.Threshold),
            TreatAccelerationFacade.Get(faceModel.Stade),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}