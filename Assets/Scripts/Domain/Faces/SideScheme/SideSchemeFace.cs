using System;

public sealed class SideSchemeFace : BaseFacade, ISideSchemeFace
{
    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    IBoostComponent IFacade<IBoostComponent>.Item => BoostItem.Item;
    int IBoostComponent.Boost => BoostItem.Boost;
    void IFacade<IBoostComponent>.AddDecorator(IDecorator<IBoostComponent> decorator) => BoostItem.AddDecorator(decorator);
    void IFacade<IBoostComponent>.RemoveDecorator(IDecorator<IBoostComponent> decorator) => BoostItem.RemoveDecorator(decorator);
    Action<IBoostComponent> IComponent<IBoostComponent>.OnChanged
    { get => BoostItem.OnChanged; set => BoostItem.OnChanged = value; }

    #endregion

    #region ITreatStartFacade

    private readonly ITreatStartFacade TreatStartItem;
    ITreatStartComponent IFacade<ITreatStartComponent>.Item => TreatStartItem.Item;
    int ITreatStartComponent.TreatStart => TreatStartItem.TreatStart;
    void IFacade<ITreatStartComponent>.AddDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.AddDecorator(decorator);
    void IFacade<ITreatStartComponent>.RemoveDecorator(IDecorator<ITreatStartComponent> decorator) => TreatStartItem.RemoveDecorator(decorator);
    Action<ITreatStartComponent> IComponent<ITreatStartComponent>.OnChanged
    { get => TreatStartItem.OnChanged; set => TreatStartItem.OnChanged = value; }

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    IWhenRevealedComponent IFacade<IWhenRevealedComponent>.Item => WhenRevealedItem.Item;
    ICommand IWhenRevealedComponent.WhenRevealed => WhenRevealedItem.WhenRevealed;
    void IFacade<IWhenRevealedComponent>.AddDecorator(IDecorator<IWhenRevealedComponent> decorator) => WhenRevealedItem.AddDecorator(decorator);
    void IFacade<IWhenRevealedComponent>.RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) => WhenRevealedItem.RemoveDecorator(decorator);
    Action<IWhenRevealedComponent> IComponent<IWhenRevealedComponent>.OnChanged
    { get => WhenRevealedItem.OnChanged; set => WhenRevealedItem.OnChanged = value; }

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
