public sealed class BasicMinionFace : BaseFace, IMinionFace
{
    #region ILife

    private readonly ILife LifeBrick;
    public int Life => LifeBrick.Life;

    #endregion

    #region IScheme

    private readonly IScheme SchemeBrick;
    public int Scheme => SchemeBrick.Scheme;

    #endregion

    #region IAttack

    private readonly IAttack AttackBrick;
    public int Attack => AttackBrick.Attack;

    #endregion

    #region IBoost

    private IBoost BoostBrick;
    public int Boost => BoostBrick.Boost;

    #endregion

    #region IWhenRevealed

    private readonly IWhenRevealed WhenRevealedBrick;
    public ICommand WhenRevealed => WhenRevealedBrick.WhenRevealed;

    #endregion

    #region Constructeur 

    private BasicMinionFace(
            ITitle titleComponent,
            ICardType cardTypeComponent,
            IClassification classificationComponent,
            ILife lifeComponent,
            IScheme schemeComponent,
            IAttack attackComponent,
            IBoost boostComponent,
            IWhenRevealed whenRevealedComponent)
        : base(
            titleComponent,
            cardTypeComponent,
            classificationComponent)
    {
        LifeBrick = lifeComponent;
        SchemeBrick = schemeComponent;
        AttackBrick = attackComponent;
        BoostBrick = boostComponent;
        WhenRevealedBrick = whenRevealedComponent;
    }

    #endregion

    #region Factory

    public static IMinionFace Get(MinionFaceModel faceModel)
        => new BasicMinionFace(
            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeComponent.Get(faceModel.CardType),
            ClassificationComponent.Get(faceModel.Classification),
            LifeComponent.Get(faceModel.Life),
            SchemeComponent.Get(faceModel.Scheme),
            AttackComponent.Get(faceModel.Attack),
            BoostComponent.Get(faceModel.Boost),
            WhenRevealedComponent.Get(NullCommand.Get()));

    #endregion
}
