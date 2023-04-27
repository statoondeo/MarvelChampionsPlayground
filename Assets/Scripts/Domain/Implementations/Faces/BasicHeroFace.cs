public sealed class BasicHeroFace : BaseFace, IHeroFace
{
    #region IThwart

    private readonly IThwart ThwartBrick;
    public int Thwart => ThwartBrick.Thwart;

    #endregion

    #region IAttack

    private readonly IAttack AttackBrick;
    public int Attack => AttackBrick.Attack;

    #endregion

    #region IDefense

    private readonly IDefense DefenseBrick;
    public int Defense => DefenseBrick.Defense;

    #endregion

    #region IHandSize

    private readonly IHandSize HandSizeBrick;
    public int HandSize => HandSizeBrick.HandSize;

    #endregion

    #region Constructeur

    private BasicHeroFace(
            ITitle title,
            ICardType cardType,
            IClassification classification,
            IThwart thwart,
            IAttack attack,
            IDefense defense,
            IHandSize handSize)
        : base(
            title,
            cardType,
            classification)
    {
        HandSizeBrick = handSize;
        ThwartBrick = thwart;
        AttackBrick = attack;
        DefenseBrick = defense;
    }

    #endregion

    #region Factory

    public static IHeroFace Get(HeroFaceModel faceModel)
        => new BasicHeroFace(
                    TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeComponent.Get(faceModel.CardType),
                    ClassificationComponent.Get(faceModel.Classification),
                    ThwartComponent.Get(faceModel.Thwart),
                    AttackComponent.Get(faceModel.Attack),
                    DefenseComponent.Get(faceModel.Defense),
                    HandSizeComponent.Get(faceModel.HandSize));

    #endregion
}
