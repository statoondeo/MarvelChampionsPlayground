using System;

public sealed class VillainFace : BaseFacade, IVillainFace
{
    #region ISchemeFacade

    private readonly ISchemeFacade SchemeItem;
    public int Scheme => SchemeItem.Scheme;
    public void AddDecorator(IDecorator<ISchemeComponent> decorator) 
        => SchemeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISchemeComponent> decorator) 
        => SchemeItem.RemoveDecorator(decorator);
    public void Register(Action<ISchemeComponent> callback) => SchemeItem.Register(callback);
    public void UnRegister(Action<ISchemeComponent> callback) => SchemeItem.UnRegister(callback);
    public void Notify(ISchemeComponent data) => SchemeItem.Notify(data);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    public int Attack => AttackItem.Attack;
    public void AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    public void Register(Action<IAttackComponent> callback) => AttackItem.Register(callback);
    public void UnRegister(Action<IAttackComponent> callback) => AttackItem.UnRegister(callback);
    public void Notify(IAttackComponent data) => AttackItem.Notify(data);

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public int Life => LifeItem.Life;
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);

    public void Register(Action<ILifeComponent> callback) => LifeItem.Register(callback);
    public void UnRegister(Action<ILifeComponent> callback) => LifeItem.UnRegister(callback);
    public void Notify(ILifeComponent data) => LifeItem.Notify(data);

    #endregion

    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    public int Stade => StadeItem.Stade;
    public void AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);
    public void Register(Action<IStadeComponent> callback) => StadeItem.Register(callback);
    public void UnRegister(Action<IStadeComponent> callback) => StadeItem.UnRegister(callback);
    public void Notify(IStadeComponent data) => StadeItem.Notify(data);

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    public ICommand Setup => SetupItem.Setup;

    public void Register(Action<ISetupComponent> callback) => SetupItem.Register(callback);
    public void UnRegister(Action<ISetupComponent> callback) => SetupItem.UnRegister(callback);
    public void Notify(ISetupComponent data) => SetupItem.Notify(data);

    public void AddDecorator(IDecorator<ISetupComponent> decorator)
        => SetupItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetupComponent> decorator)
        => SetupItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;

    public void Register(Action<IWhenRevealedComponent> callback) => WhenRevealedItem.Register(callback);
    public void UnRegister(Action<IWhenRevealedComponent> callback) => WhenRevealedItem.UnRegister(callback);
    public void Notify(IWhenRevealedComponent data) => WhenRevealedItem.Notify(data);

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