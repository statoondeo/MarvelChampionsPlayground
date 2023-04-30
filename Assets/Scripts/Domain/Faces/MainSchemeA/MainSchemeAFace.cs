using System;

public sealed class MainSchemeAFace : BaseFacade, IMainSchemeAFace
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

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    ISetupComponent IFacade<ISetupComponent>.Item => SetupItem.Item;
    ICommand ISetupComponent.Setup => SetupItem.Setup;
    void IFacade<ISetupComponent>.AddDecorator(IDecorator<ISetupComponent> decorator) => SetupItem.AddDecorator(decorator);
    void IFacade<ISetupComponent>.RemoveDecorator(IDecorator<ISetupComponent> decorator) => SetupItem.RemoveDecorator(decorator);
    Action<ISetupComponent> IComponent<ISetupComponent>.OnChanged
    { get => SetupItem.OnChanged; set => SetupItem.OnChanged = value; }

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
