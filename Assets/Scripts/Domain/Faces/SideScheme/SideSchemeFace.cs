﻿public sealed class SideSchemeFace : BaseFace, ISideSchemeFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        TreatItem.SetCard(card);
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

    #region ITreatFacade

    private readonly ITreatFacade TreatItem;
    public int CurrentTreat => TreatItem.CurrentTreat;
    public void AddTreat(int treat) => TreatItem.AddTreat(treat);
    public void RemoveTreat(int treat) => TreatItem.RemoveTreat(treat);
    public void AddDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatComponent> decorator) => TreatItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private SideSchemeFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ITreatFacade treatFacade,
            IBoostFacade boostFacade,
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
            TreatFacade.Get(faceModel.Starting),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(PermanentWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
