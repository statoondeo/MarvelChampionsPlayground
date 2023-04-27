public sealed class BasicVillainFace : BaseFace, IVillainFace
{
    #region IScheme

    private readonly IScheme SchemeBrick;
    public int Scheme => SchemeBrick.Scheme;

    #endregion

    #region IAttack

    private readonly IAttack AttackBrick;
    public int Attack => AttackBrick.Attack;

    #endregion

    #region ILife

    private readonly ILife LifeBrick;
    public int Life => LifeBrick.Life;

    #endregion

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

    private BasicVillainFace(
            ITitle title,
            ICardType cardType,
            IClassification classification,
            IScheme schemeComponent,
            IAttack attack,
            IStade stadeComponent,
            ILife lifeComponent,
            ISetup setupComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            title,
            cardType,
            classification)
    {
        LifeBrick = lifeComponent;
        SchemeBrick = schemeComponent;
        AttackBrick = attack;
        StadeBrick = stadeComponent;
        SetupBrick = setupComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static IVillainFace Get(VillainFaceModel faceModel)
        => new BasicVillainFace(
                    TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeComponent.Get(faceModel.CardType),
                    ClassificationComponent.Get(faceModel.Classification),
                    SchemeComponent.Get(faceModel.Scheme),
                    AttackComponent.Get(faceModel.Attack),
                    StadeComponent.Get(faceModel.Stade),
                    LifeComponent.Get(faceModel.Life),
                    SetupComponent.Get(NullCommand.Get()),
                    WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}