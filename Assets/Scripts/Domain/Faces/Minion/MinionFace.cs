using System;

public sealed class MinionFace : CoreFacade, IMinionFace
{
    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    public void AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);
    public void Register(Action<ILifeComponent> callback) => LifeItem.Register(callback);
    public void UnRegister(Action<ILifeComponent> callback) => LifeItem.UnRegister(callback);
    public void Notify(ILifeComponent data) => LifeItem.Notify(data);

    public int CurrentLife => LifeItem.CurrentLife;
    public int TotalLife => LifeItem.TotalLife;
    public int Damage => LifeItem.Damage;
    public void TakeDamage(int damage) => LifeItem.TakeDamage(damage);

    #endregion

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

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void Register(Action<IBoostComponent> callback) => BoostItem.Register(callback);
    public void UnRegister(Action<IBoostComponent> callback) => BoostItem.UnRegister(callback);
    public void Notify(IBoostComponent data) => BoostItem.Notify(data);
    public void AddDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

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
