public sealed class MinionFace : BaseCardFace, IMinionFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        LifeItem.SetCard(card);
        SchemeItem.SetCard(card);
        AttackItem.SetCard(card);
        BoostItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
        card.GetFacade<IEnterPlayComponent>().SetCard(card);
    }

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

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void AddDecorator(ICardComponentDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void Reveal() => WhenRevealedItem.Reveal();
    public void AddDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IWhenRevealedComponent> decorator)
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur 

    private MinionFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            ISchemeFacade schemeFacade,
            IAttackFacade attackFacade,
            IBoostFacade boostFacade,
            IEnterPlayFacade enterPlayFacade,
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
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<ILifeComponent>(LifeItem);
        Mediator.Register<ISchemeComponent>(SchemeItem);
        Mediator.Register<IAttackComponent>(AttackItem);
        Mediator.Register<IBoostComponent>(BoostItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
        Mediator.Register<IEnterPlayComponent>(enterPlayFacade);
    }

    #endregion

    #region Factory

    public static IMinionFace Get(IMediator<ICardComponent> mediator, MinionFaceModel faceModel)
        => new MinionFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            LifeFacade.Get(faceModel.Life),
            SchemeFacade.Get(faceModel.Scheme),
            AttackFacade.Get(faceModel.Attack),
            BoostFacade.Get(faceModel.Boost),
            EnterPlayFacade.Get(SingleFaceEnterPlayComponent.Get()),
            WhenRevealedFacade.Get(PermanentWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
