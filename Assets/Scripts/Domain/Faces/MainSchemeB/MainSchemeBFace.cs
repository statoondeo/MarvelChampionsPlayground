using System;

public sealed class MainSchemeBFace : BaseFacade, IMainSchemeBFace
{
    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    IStadeComponent IFacade<IStadeComponent>.Item => StadeItem.Item;
    int IStadeComponent.Stade => StadeItem.Stade;
    void IFacade<IStadeComponent>.AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    void IFacade<IStadeComponent>.RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);
    Action<IStadeComponent> IComponent<IStadeComponent>.OnChanged
    { get => StadeItem.OnChanged; set => StadeItem.OnChanged = value; }

    #endregion

    #region ITreatThresholdFacade

    private readonly ITreatThresholdFacade TreatThresholdItem;
    ITreatThresholdComponent IFacade<ITreatThresholdComponent>.Item => TreatThresholdItem.Item;
    int ITreatThresholdComponent.TreatThreshold => TreatThresholdItem.TreatThreshold;
    void IFacade<ITreatThresholdComponent>.AddDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.AddDecorator(decorator);
    void IFacade<ITreatThresholdComponent>.RemoveDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.RemoveDecorator(decorator);
    Action<ITreatThresholdComponent> IComponent<ITreatThresholdComponent>.OnChanged
    { get => TreatThresholdItem.OnChanged; set => TreatThresholdItem.OnChanged = value; }

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

    #region ITreatAccelerationFacade

    private readonly ITreatAccelerationFacade TreatAccelerationItem;
    ITreatAccelerationComponent IFacade<ITreatAccelerationComponent>.Item => TreatAccelerationItem.Item;
    int ITreatAccelerationComponent.TreatAcceleration => TreatAccelerationItem.TreatAcceleration;
    void IFacade<ITreatAccelerationComponent>.AddDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.AddDecorator(decorator);
    void IFacade<ITreatAccelerationComponent>.RemoveDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.RemoveDecorator(decorator);
    Action<ITreatAccelerationComponent> IComponent<ITreatAccelerationComponent>.OnChanged
    { get => TreatAccelerationItem.OnChanged; set => TreatAccelerationItem.OnChanged = value; }

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