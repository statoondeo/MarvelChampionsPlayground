public sealed class BasicMainSchemeAFace : BaseFace, IMainSchemeAFace
{
    #region IStade

    private readonly IStade StadeBrick;
    public int Stade => StadeBrick.Stade;

    #endregion

    #region ISetup

    private readonly ISetup SetupBrick;
    public ICommand Setup => SetupBrick.Setup;

    #endregion

    #region IWhenRevealed

    private readonly IWhenRevealed WhenRevealedBrick;
    public ICommand WhenRevealed => WhenRevealedBrick.WhenRevealed;

    #endregion

    #region Constructeur

    private BasicMainSchemeAFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            IStade stadeComponent,
            ISetup setupComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        StadeBrick = stadeComponent;
        SetupBrick = setupComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static IMainSchemeAFace Get(MainSchemeAFaceModel faceModel)
        => new BasicMainSchemeAFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            StadeComponent.Get(faceModel.Stade),
            SetupComponent.Get(NullCommand.Get()),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}
