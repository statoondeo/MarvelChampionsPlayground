public sealed class VillainFace : CoreFacade, IVillainFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        LifeItem.SetCard(card);
        SchemeItem.SetCard(card);
        AttackItem.SetCard(card);
        StadeItem.SetCard(card);
        SetupItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #region ISchemeFacade

    private readonly ISchemeFacade SchemeItem;
    public int Scheme => SchemeItem.Scheme;
    public void AddDecorator(IDecorator<ISchemeComponent> decorator)
        => SchemeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISchemeComponent> decorator)
        => SchemeItem.RemoveDecorator(decorator);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    public int Attack => AttackItem.Attack;
    public void AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);

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

    #endregion

    #region Constructeur

    private VillainFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ISchemeFacade schemeFacade,
            IAttackFacade attackFacade,
            IStadeFacade stadeFacade,
            ILifeFacade lifeFacade,
            ISetupFacade setupFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        LifeItem = lifeFacade;
        SchemeItem = schemeFacade;
        AttackItem = attackFacade;
        StadeItem = stadeFacade;
        SetupItem = setupFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static IVillainFace Get(VillainFaceModel faceModel)
        => new VillainFace(
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    CardTypeFacade.Get(faceModel.CardType),
                    ClassificationFacade.Get(faceModel.Classification),
                    SchemeFacade.Get(faceModel.Scheme),
                    AttackFacade.Get(faceModel.Attack),
                    StadeFacade.Get(faceModel.Stade),
                    LifeFacade.Get(faceModel.Life),
                    SetupFacade.Get(NullCommand.Get()),
                    WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}