public sealed class AllyFace : BaseCardFace, IAllyFace
{
    #region Constructor

    private AllyFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade, 
            IFaceTypeFacade cardTypeFacade, 
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IResourceGeneratorFacade resourceFacade,
            IEnterPlayFacade enterPlayFacade,
            ICostFacade costFacade)
        : base(
            mediator,
            titleFacade, 
            cardTypeFacade, 
            classificationFacade) 
    {
        LifeItem = lifeFacade;
        ThwartItem = thwartFacade;
        AttackItem = attackFacade;
        ResourceItem = resourceFacade;
        CostItem = costFacade;

        Mediator.Register<ILifeComponent>(LifeItem);
        Mediator.Register<IThwartComponent>(ThwartItem);
        Mediator.Register<IAttackComponent>(AttackItem);
        Mediator.Register<IResourceGeneratorComponent>(ResourceItem);
        Mediator.Register<ICostComponent>(CostItem);
        Mediator.Register<IEnterPlayComponent>(enterPlayFacade);
    }

    #endregion

    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        ThwartItem.SetCard(card);
        AttackItem.SetCard(card);
        LifeItem.SetCard(card);
        CostItem.SetCard(card);
        ResourceItem.SetCard(card);
        card.GetFacade<IEnterPlayComponent>().SetCard(card);
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

    #region ICostFacade

    private readonly ICostFacade CostItem;
    public int Cost => CostItem.Cost;
    public void Play() => CostItem.Play();
    public void Resolve() => CostItem.Resolve();
    public void AddDecorator(ICardComponentDecorator<ICostComponent> decorator)
        => CostItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ICostComponent> decorator)
        => CostItem.RemoveDecorator(decorator);

    #endregion

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;

    public int Energy => ResourceItem.Energy;
    public int Mental => ResourceItem.Mental;
    public int Physic => ResourceItem.Physic;
    public int Wild => ResourceItem.Wild;

    public void AddDecorator(ICardComponentDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.RemoveDecorator(decorator);

    #endregion

    #region Factory

    public static ICardFace Get(IMediator<ICardComponent> mediator, AllyFaceModel faceModel)
    {
        return new AllyFace(
                mediator,
                TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                FaceTypeFacade.Get(faceModel.FaceType),
                ClassificationFacade.Get(faceModel.Classification),
                LifeFacade.Get(faceModel.Life),
                ThwartFacade.Get(faceModel.Thwart),
                AttackFacade.Get(faceModel.Attack),
                ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
                EnterPlayFacade.Get(SingleFaceEnterPlayComponent.Get()),
                CostFacade.Get(PermanentCostComponent.Get(faceModel.Cost)));
    }

    #endregion
}
