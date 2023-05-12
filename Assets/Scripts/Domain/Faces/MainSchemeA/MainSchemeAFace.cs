public sealed class MainSchemeAFace : BaseFace, IMainSchemeAFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        StadeItem.SetCard(card);
        SetupItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #endregion

    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;
    public void AddDecorator(IDecorator<ISetupComponent> decorator)
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetupComponent> decorator)
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);
    public void Reveal() => WhenRevealedItem.Reveal();

    #endregion

    #region Constructeur

    private MainSchemeAFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IStadeFacade stadeFacade,
            ISetupFacade setupFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        StadeItem = stadeFacade;
        SetupItem = setupFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<IStadeComponent>(StadeItem);
        Mediator.Register<ISetupComponent>(SetupItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
    }

    #endregion

    #region Factory

    public static IMainSchemeAFace Get(IMediator<IComponent> mediator, MainSchemeAFaceModel faceModel)
        => new MainSchemeAFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            StadeFacade.Get(faceModel.Stade),
            SetupFacade.Get(NullCommand.Get()),
            WhenRevealedFacade.Get(StaticWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
