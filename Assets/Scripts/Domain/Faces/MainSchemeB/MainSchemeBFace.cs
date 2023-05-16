public sealed class MainSchemeBFace : BaseFace, IMainSchemeBFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        StadeItem.SetCard(card);
        TreatAccelerationItem.SetCard(card);
        TreatItem.SetCard(card);
        TreatThresholdItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
        Mediator.GetFacade<IEnterPlayComponent>().SetCard(card);
    }

    #endregion

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

    #region ITreatFacade

    private readonly ITreatFacade TreatItem;
    public int CurrentTreat => TreatItem.CurrentTreat;
    public void AddDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.RemoveDecorator(decorator);
    public void AddTreat(int treat) => TreatItem.AddTreat(treat);
    public void RemoveTreat(int treat) => TreatItem.RemoveTreat(treat);

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
    public void Reveal() => WhenRevealedItem.Reveal();
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private MainSchemeBFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IStadeFacade stadeFacade,
            ITreatFacade treatFacade,
            ITreatThresholdFacade treatThresholdFacade,
            ITreatAccelerationFacade treatAccelerationFacade,
            IEnterPlayFacade enterPlayFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
             mediator,
           titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        StadeItem = stadeFacade;
        TreatItem = treatFacade;
        TreatThresholdItem = treatThresholdFacade;
        TreatAccelerationItem = treatAccelerationFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<IStadeComponent>(StadeItem);
        Mediator.Register<ITreatComponent>(TreatItem);
        Mediator.Register<ITreatThresholdComponent>(TreatThresholdItem);
        Mediator.Register<ITreatAccelerationComponent>(TreatAccelerationItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
        Mediator.Register<IEnterPlayComponent>(enterPlayFacade);
    }

    #endregion

    #region Factory

    public static IMainSchemeBFace Get(IMediator<IComponent> mediator, MainSchemeBFaceModel faceModel)
        => new MainSchemeBFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            StadeFacade.Get(faceModel.Stade),
            TreatFacade.Get(faceModel.Starting),
            TreatThresholdFacade.Get(faceModel.Threshold),
            TreatAccelerationFacade.Get(faceModel.Stade),
            EnterPlayFacade.Get(SchemeEnterPlayComponent.Get()),
            WhenRevealedFacade.Get(StaticWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}