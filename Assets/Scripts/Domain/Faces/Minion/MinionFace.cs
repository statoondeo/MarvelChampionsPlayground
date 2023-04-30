using System;

public sealed class MinionFace : BaseFacade, IMinionFace
{
    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    ILifeComponent IFacade<ILifeComponent>.Item => LifeItem.Item;
    int ILifeComponent.Life => LifeItem.Life;
    void IFacade<ILifeComponent>.AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    void IFacade<ILifeComponent>.RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    Action<ILifeComponent> IComponent<ILifeComponent>.OnChanged
    { get => LifeItem.OnChanged; set => LifeItem.OnChanged = value; }

    #endregion

    #region ISchemeFacade

    private readonly ISchemeFacade SchemeItem;
    ISchemeComponent IFacade<ISchemeComponent>.Item => SchemeItem.Item;
    int ISchemeComponent.Scheme => SchemeItem.Scheme;
    void IFacade<ISchemeComponent>.AddDecorator(IDecorator<ISchemeComponent> decorator) => SchemeItem.AddDecorator(decorator);
    void IFacade<ISchemeComponent>.RemoveDecorator(IDecorator<ISchemeComponent> decorator) => SchemeItem.RemoveDecorator(decorator);
    Action<ISchemeComponent> IComponent<ISchemeComponent>.OnChanged
    { get => SchemeItem.OnChanged; set => SchemeItem.OnChanged = value; }

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    IAttackComponent IFacade<IAttackComponent>.Item => AttackItem.Item;
    int IAttackComponent.Attack => AttackItem.Attack;
    void IFacade<IAttackComponent>.AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    void IFacade<IAttackComponent>.RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);
    Action<IAttackComponent> IComponent<IAttackComponent>.OnChanged
    { get => AttackItem.OnChanged; set => AttackItem.OnChanged = value; }

    #endregion

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    IBoostComponent IFacade<IBoostComponent>.Item => BoostItem.Item;
    int IBoostComponent.Boost => BoostItem.Boost;
    void IFacade<IBoostComponent>.AddDecorator(IDecorator<IBoostComponent> decorator) => BoostItem.AddDecorator(decorator);
    void IFacade<IBoostComponent>.RemoveDecorator(IDecorator<IBoostComponent> decorator) => BoostItem.RemoveDecorator(decorator);
    Action<IBoostComponent> IComponent<IBoostComponent>.OnChanged
    { get => BoostItem.OnChanged; set => BoostItem.OnChanged = value; }

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

    private MinionFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            ISchemeFacade schemeFacade,
            IAttackFacade attackFacade,
            IBoostFacade boostFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        LifeItem = lifeFacade;
        SchemeItem = schemeFacade;
        AttackItem = attackFacade;
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static IMinionFace Get(MinionFaceModel faceModel)
        => new MinionFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            LifeFacade.Get(faceModel.Life),
            SchemeFacade.Get(faceModel.Scheme),
            AttackFacade.Get(faceModel.Attack),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}
