using System;

public sealed class SideSchemeFace : BaseFacade, ISideSchemeFace
{
    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void Register(Action<IBoostComponent> callback) => BoostItem.Register(callback);
    public void UnRegister(Action<IBoostComponent> callback) => BoostItem.UnRegister(callback);
    public void Notify(IBoostComponent data) => BoostItem.Notify(data);
    public void AddDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;

    public void Register(Action<IWhenRevealedComponent> callback) => WhenRevealedItem.Register(callback);
    public void UnRegister(Action<IWhenRevealedComponent> callback) => WhenRevealedItem.UnRegister(callback);
    public void Notify(IWhenRevealedComponent data) => WhenRevealedItem.Notify(data);

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
    public void Register(Action<ITreatStartComponent> callback) => TreatStartItem.Register(callback);
    public void UnRegister(Action<ITreatStartComponent> callback) => TreatStartItem.UnRegister(callback);
    public void Notify(ITreatStartComponent data) => TreatStartItem.Notify(data);

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
