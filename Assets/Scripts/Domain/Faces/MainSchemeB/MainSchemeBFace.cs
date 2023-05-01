using System;

public sealed class MainSchemeBFace : BaseFacade, IMainSchemeBFace
{
    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);
    public void Register(Action<IStadeComponent> callback) => StadeItem.Register(callback);
    public void UnRegister(Action<IStadeComponent> callback) => StadeItem.UnRegister(callback);
    public void Notify(IStadeComponent data) => StadeItem.Notify(data);

    #endregion

    #region ITreatThresholdFacade

    private readonly ITreatThresholdFacade TreatThresholdItem;
    public int TreatThreshold => TreatThresholdItem.TreatThreshold;
    public void AddDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatThresholdComponent> decorator) => TreatThresholdItem.RemoveDecorator(decorator);
    public void Register(Action<ITreatThresholdComponent> callback) => TreatThresholdItem.Register(callback);
    public void UnRegister(Action<ITreatThresholdComponent> callback) => TreatThresholdItem.UnRegister(callback);
    public void Notify(ITreatThresholdComponent data) => TreatThresholdItem.Notify(data);

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

    #region ITreatAccelerationFacade

    private readonly ITreatAccelerationFacade TreatAccelerationItem;
    public int TreatAcceleration => TreatAccelerationItem.TreatAcceleration;
    public void AddDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatAccelerationComponent> decorator) => TreatAccelerationItem.RemoveDecorator(decorator);
    public void Register(Action<ITreatAccelerationComponent> callback) => TreatAccelerationItem.Register(callback);
    public void UnRegister(Action<ITreatAccelerationComponent> callback) => TreatAccelerationItem.UnRegister(callback);
    public void Notify(ITreatAccelerationComponent data) => TreatAccelerationItem.Notify(data);

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