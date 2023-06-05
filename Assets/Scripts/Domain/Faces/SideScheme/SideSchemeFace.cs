public sealed class SideSchemeFace : BaseCardFace, ISideSchemeFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        TreatItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
        card.GetFacade<IEnterPlayComponent>().SetCard(card);
    }

    #endregion

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void AddDecorator(ICardComponentDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region ITreatFacade

    private readonly ITreatFacade TreatItem;
    public int CurrentTreat => TreatItem.CurrentTreat;
    public void AddTreat(int treat) => TreatItem.AddTreat(treat);
    public void RemoveTreat(int treat) => TreatItem.RemoveTreat(treat);
    public void AddDecorator(ICardComponentDecorator<ITreatComponent> decorator) => TreatItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ITreatComponent> decorator) => TreatItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private SideSchemeFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ITreatFacade treatFacade,
            IBoostFacade boostFacade,
            IEnterPlayFacade enterPlayFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        TreatItem = treatFacade;
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<ITreatComponent>(TreatItem);
        Mediator.Register<IBoostComponent>(BoostItem);
        Mediator.Register<IEnterPlayComponent>(enterPlayFacade);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
    }

    #endregion

    #region Factory

    public static ISideSchemeFace Get(IGame game, IMediator<ICardComponent> mediator, SideSchemeFaceModel faceModel)
        => new SideSchemeFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            TreatFacade.Get(faceModel.Starting),
            BoostFacade.Get(faceModel.Boost),
            EnterPlayFacade.Get(SchemeEnterPlayComponent.Get()),
            WhenRevealedFacade.Get(StaticWhenRevealedComponent.Get(new CommandFactory(game).Create(faceModel.WhenRevealedCommand))));

    #endregion
}
