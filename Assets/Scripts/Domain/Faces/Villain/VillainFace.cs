public sealed class VillainFace : BaseCardFace, IVillainFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        LifeItem.SetCard(card);
        SchemeItem.SetCard(card);
        AttackItem.SetCard(card);
        StadeItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #endregion

    #region ISchemeFacade

    private readonly ISchemeFacade SchemeItem;
    public int Scheme => SchemeItem.Scheme;
    public void AddDecorator(ICardComponentDecorator<ISchemeComponent> decorator)
        => SchemeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ISchemeComponent> decorator)
        => SchemeItem.RemoveDecorator(decorator);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    public int Attack => AttackItem.Attack;
    public void AddDecorator(ICardComponentDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(ICardComponentDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);
    public void HealDamage(int damage) => LifeItem.HealDamage(damage);

    #endregion

    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(ICardComponentDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private VillainFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ISchemeFacade schemeFacade,
            IAttackFacade attackFacade,
            IStadeFacade stadeFacade,
            ILifeFacade lifeFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        LifeItem = lifeFacade;
        SchemeItem = schemeFacade;
        AttackItem = attackFacade;
        StadeItem = stadeFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<ILifeComponent>(LifeItem);
        Mediator.Register<ISchemeComponent>(SchemeItem);
        Mediator.Register<IAttackComponent>(AttackItem);
        Mediator.Register<IStadeComponent>(StadeItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
    }

    #endregion

    #region Factory

    public static IVillainFace Get(IGame game, IMediator<ICardComponent> mediator, VillainFaceModel faceModel)
        => new VillainFace(
                    mediator,
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    FaceTypeFacade.Get(faceModel.FaceType),
                    ClassificationFacade.Get(faceModel.Classification),
                    SchemeFacade.Get(faceModel.Scheme),
                    AttackFacade.Get(faceModel.Attack),
                    StadeFacade.Get(faceModel.Stade),
                    LifeFacade.Get(faceModel.Life),
                    WhenRevealedFacade.Get(StaticWhenRevealedComponent.Get(new CommandFactory(game).Create(faceModel.WhenRevealedCommand))));

    #endregion
}