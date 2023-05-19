public sealed class HeroFace : BaseCardFace, IHeroFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        ThwartItem.SetCard(card);
        AttackItem.SetCard(card);
        DefenseItem.SetCard(card);
        HandSizeItem.SetCard(card);
    }

    #endregion

    #region IThwartFacade

    private readonly IThwartFacade ThwartItem;
    public int Thwart => ThwartItem.Thwart;
    public void AddDecorator(ICardComponentDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    public int Attack => AttackItem.Attack;
    public void AddDecorator(ICardComponentDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    #endregion

    #region IDefenseFacade

    private readonly IDefenseFacade DefenseItem;
    public int Defense => DefenseItem.Defense;
    public void AddDecorator(ICardComponentDecorator<IDefenseComponent> decorator) => DefenseItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IDefenseComponent> decorator) => DefenseItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    public int HandSize => HandSizeItem.HandSize;
    public void AddDecorator(ICardComponentDecorator<IHandSizeComponent> decorator)
        => HandSizeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IHandSizeComponent> decorator)
        => HandSizeItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private HeroFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IDefenseFacade defenseFacade,
            IHandSizeFacade handSizeFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        HandSizeItem = handSizeFacade;
        ThwartItem = thwartFacade;
        AttackItem = attackFacade;
        DefenseItem = defenseFacade;

        Mediator.Register<IHandSizeComponent>(HandSizeItem);
        Mediator.Register<IThwartComponent>(ThwartItem);
        Mediator.Register<IAttackComponent>(AttackItem);
        Mediator.Register<IDefenseComponent>(DefenseItem);
    }

    #endregion

    #region Factory

    public static IHeroFace Get(IMediator<ICardComponent> mediator, HeroFaceModel faceModel)
        => new HeroFace(
                    mediator,
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    FaceTypeFacade.Get(faceModel.FaceType),
                    ClassificationFacade.Get(faceModel.Classification),
                    ThwartFacade.Get(faceModel.Thwart),
                    AttackFacade.Get(faceModel.Attack),
                    DefenseFacade.Get(faceModel.Defense),
                    HandSizeFacade.Get(faceModel.HandSize));

    #endregion
}
