using System;

public sealed class AlterEgoFace : CoreFacade, IAlterEgoFace
{
    #region IRecoveryFacade

    private readonly IRecoveryFacade RecoveryItem;
    public int Recovery => RecoveryItem.Recovery;
    public void AddDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.RemoveDecorator(decorator);

    public void Register(Action<IRecoveryComponent> callback) => RecoveryItem.Register(callback);
    public void UnRegister(Action<IRecoveryComponent> callback) => RecoveryItem.UnRegister(callback);
    public void Notify(IRecoveryComponent data) => RecoveryItem.Notify(data);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    public int HandSize => HandSizeItem.HandSize;
    public void AddDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.RemoveDecorator(decorator);

    public void Register(Action<IHandSizeComponent> callback) => HandSizeItem.Register(callback);
    public void UnRegister(Action<IHandSizeComponent> callback) => HandSizeItem.UnRegister(callback);
    public void Notify(IHandSizeComponent data) => HandSizeItem.Notify(data);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;

    public void Register(Action<ISetupComponent> callback) => SetupItem.Register(callback);
    public void UnRegister(Action<ISetupComponent> callback) => SetupItem.UnRegister(callback);
    public void Notify(ISetupComponent data) => SetupItem.Notify(data);

    public void AddDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    public AlterEgoFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IRecoveryFacade recoveryFacade,
            IHandSizeFacade handSizeFacade,
            ISetupFacade setupFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        RecoveryItem = recoveryFacade;
        HandSizeItem = handSizeFacade;
        SetupItem = setupFacade;
    }

    #endregion

    #region Factory

    public static IAlterEgoFace Get(AlterEgoFaceModel faceModel)
        => new AlterEgoFace(
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    RecoveryFacade.Get(faceModel.Recovery),
                    HandSizeFacade.Get(faceModel.HandSize),
                    SetupFacade.Get(NullCommand.Get()));

    #endregion
}
