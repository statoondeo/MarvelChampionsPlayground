public sealed class AlterEgoFace : BaseCardFace, IAlterEgoFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        RecoveryItem.SetCard(card);
        HandSizeItem.SetCard(card);
        SetupItem.SetCard(card);
        LifeItem.SetCard(card);
    }

    #endregion

    #region IRecoveryFacade

    private readonly IRecoveryFacade RecoveryItem;
    public int Recovery => RecoveryItem.Recovery;
    public void AddDecorator(ICardComponentDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IRecoveryComponent> decorator) 
        => RecoveryItem.RemoveDecorator(decorator);

    #endregion

    #region IHandSizeFacade

    private readonly IHandSizeFacade HandSizeItem;
    public int HandSize => HandSizeItem.HandSize;
    public void AddDecorator(ICardComponentDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IHandSizeComponent> decorator) 
        => HandSizeItem.RemoveDecorator(decorator);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;
    public void AddDecorator(ICardComponentDecorator<ISetupComponent> decorator) 
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<ISetupComponent> decorator) 
        => SetupItem.RemoveDecorator(decorator);

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

    #region Constructeur

    public AlterEgoFace(
            IMediator<ICardComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IRecoveryFacade recoveryFacade,
            IHandSizeFacade handSizeFacade,
            ISetupFacade setupFacade,
            ILifeFacade lifeFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        RecoveryItem = recoveryFacade;
        HandSizeItem = handSizeFacade;
        SetupItem = setupFacade;
        LifeItem = lifeFacade;

        Mediator.Register<IRecoveryComponent>(RecoveryItem);
        Mediator.Register<IHandSizeComponent>(HandSizeItem);
        Mediator.Register<ISetupComponent>(SetupItem);
        Mediator.Register<ILifeComponent>(LifeItem);
    }

    #endregion

    #region Factory

    public static IAlterEgoFace Get(IGame game, IMediator<ICardComponent> mediator, ILifeFacade lifeFacade, AlterEgoFaceModel faceModel)
        => new AlterEgoFace(
                    mediator,
                    TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                    FaceTypeFacade.Get(faceModel.FaceType),
                    ClassificationFacade.Get(faceModel.Classification),
                    RecoveryFacade.Get(faceModel.Recovery),
                    HandSizeFacade.Get(faceModel.HandSize),
                    SetupFacade.Get(new CommandFactory(game).Create(faceModel.SetupCommand)),
                    lifeFacade);

    #endregion
}
