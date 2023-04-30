using System;

public sealed class VillainFace : BaseFacade, IVillainFace
{
    #region ISchemeFacade

    private readonly ISchemeFacade SchemeItem;
    ISchemeComponent IFacade<ISchemeComponent>.Item => SchemeItem.Item;
    int ISchemeComponent.Scheme => SchemeItem.Scheme;
    void IFacade<ISchemeComponent>.AddDecorator(IDecorator<ISchemeComponent> decorator) 
        => SchemeItem.AddDecorator(decorator);
    void IFacade<ISchemeComponent>.RemoveDecorator(IDecorator<ISchemeComponent> decorator) 
        => SchemeItem.RemoveDecorator(decorator);
    Action<ISchemeComponent> IComponent<ISchemeComponent>.OnChanged
    { get => SchemeItem.OnChanged; set => SchemeItem.OnChanged = value; }

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    IAttackComponent IFacade<IAttackComponent>.Item => AttackItem.Item;
    int IAttackComponent.Attack => AttackItem.Attack;
    void IFacade<IAttackComponent>.AddDecorator(IDecorator<IAttackComponent> decorator) 
        => AttackItem.AddDecorator(decorator);
    void IFacade<IAttackComponent>.RemoveDecorator(IDecorator<IAttackComponent> decorator) 
        => AttackItem.RemoveDecorator(decorator);
    Action<IAttackComponent> IComponent<IAttackComponent>.OnChanged
    { get => AttackItem.OnChanged; set => AttackItem.OnChanged = value; }

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    ILifeComponent IFacade<ILifeComponent>.Item => LifeItem.Item;
    int ILifeComponent.Life => LifeItem.Life;
    void IFacade<ILifeComponent>.AddDecorator(IDecorator<ILifeComponent> decorator) 
        => LifeItem.AddDecorator(decorator);
    void IFacade<ILifeComponent>.RemoveDecorator(IDecorator<ILifeComponent> decorator) 
        => LifeItem.RemoveDecorator(decorator);
    Action<ILifeComponent> IComponent<ILifeComponent>.OnChanged
    { get => LifeItem.OnChanged; set => LifeItem.OnChanged = value; }

    #endregion

    #region IStadeFacade

    private readonly IStadeFacade StadeItem;
    IStadeComponent IFacade<IStadeComponent>.Item => StadeItem.Item;
    int IStadeComponent.Stade => StadeItem.Stade;
    void IFacade<IStadeComponent>.AddDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.AddDecorator(decorator);
    void IFacade<IStadeComponent>.RemoveDecorator(IDecorator<IStadeComponent> decorator) => StadeItem.RemoveDecorator(decorator);
    Action<IStadeComponent> IComponent<IStadeComponent>.OnChanged
    { get => StadeItem.OnChanged; set => StadeItem.OnChanged = value; }

    #endregion

    #region ISetupFacade

    private readonly ISetupFacade SetupItem;
    ISetupComponent IFacade<ISetupComponent>.Item => SetupItem.Item;
    ICommand ISetupComponent.Setup => SetupItem.Setup;
    void IFacade<ISetupComponent>.AddDecorator(IDecorator<ISetupComponent> decorator) 
        => SetupItem.AddDecorator(decorator);
    void IFacade<ISetupComponent>.RemoveDecorator(IDecorator<ISetupComponent> decorator)
        => SetupItem.RemoveDecorator(decorator);
    Action<ISetupComponent> IComponent<ISetupComponent>.OnChanged
    { get => SetupItem.OnChanged; set => SetupItem.OnChanged = value; }

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    IWhenRevealedComponent IFacade<IWhenRevealedComponent>.Item => WhenRevealedItem.Item;
    ICommand IWhenRevealedComponent.WhenRevealed => WhenRevealedItem.WhenRevealed;
    void IFacade<IWhenRevealedComponent>.AddDecorator(IDecorator<IWhenRevealedComponent> decorator) => WhenRevealedItem.AddDecorator(decorator);
    void IFacade<IWhenRevealedComponent>.RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) => WhenRevealedItem.RemoveDecorator(decorator);
    Action<IWhenRevealedComponent> IComponent<IWhenRevealedComponent>.OnChanged
    { get => WhenRevealedItem.OnChanged; set => WhenRevealedItem.OnChanged = value; }

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