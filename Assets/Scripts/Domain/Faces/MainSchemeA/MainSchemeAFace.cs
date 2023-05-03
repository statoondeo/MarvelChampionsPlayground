using System;

public sealed class MainSchemeAFace : CoreFacade, IMainSchemeAFace
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

    private MainSchemeAFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IStadeFacade stadeFacade,
            ISetupFacade setupFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        StadeItem = stadeFacade;
        SetupItem = setupFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static IMainSchemeAFace Get(MainSchemeAFaceModel faceModel)
        => new MainSchemeAFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            StadeFacade.Get(faceModel.Stade),
            SetupFacade.Get(NullCommand.Get()),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}
