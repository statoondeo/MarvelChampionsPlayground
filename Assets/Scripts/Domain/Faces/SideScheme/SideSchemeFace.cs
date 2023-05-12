public sealed class SideSchemeFace : BaseFace, ISideSchemeFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        ResetItem.SetCard(card);
        TreatItem.SetCard(card);
        TreatStartItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
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

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void Reveal() => WhenRevealedItem.Reveal();
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

    #region ITreatFacade

    private readonly ITreatFacade TreatItem;
    public int CurrentTreat => TreatItem.CurrentTreat;
    public void AddTreat(int treat) => TreatItem.AddTreat(treat);
    public void RemoveTreat(int treat) => TreatItem.RemoveTreat(treat);
    public void AddDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.RemoveDecorator(decorator);

    #endregion

    #region IResetFacade

    private readonly IResetFacade ResetItem;
    public void Reset() => ResetItem.Reset();
    public void AddDecorator(IDecorator<IResetComponent> decorator)
        => ResetItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResetComponent> decorator)
        => ResetItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private SideSchemeFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ITreatStartFacade treatStartFacade,
            ITreatFacade treatFacade,
            IBoostFacade boostFacade,
            IResetFacade resetFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
             mediator,
           titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        TreatStartItem = treatStartFacade;
        TreatItem = treatFacade;
        BoostItem = boostFacade;
        ResetItem = resetFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<ITreatStartComponent>(TreatStartItem);
        Mediator.Register<ITreatComponent>(TreatItem);
        Mediator.Register<IBoostComponent>(BoostItem);
        Mediator.Register<IResetComponent>(ResetItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
    }

    #endregion

    #region Factory

    public static ISideSchemeFace Get(IMediator<IComponent> mediator, SideSchemeFaceModel faceModel)
        => new SideSchemeFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            TreatStartFacade.Get(faceModel.Starting),
            TreatFacade.Get(),
            BoostFacade.Get(faceModel.Boost),
            ResetFacade.Get(BasicResetComponent.Get()),
            WhenRevealedFacade.Get(PermanentWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
