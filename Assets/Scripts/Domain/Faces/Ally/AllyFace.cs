using System;

public sealed class AllyFace : CoreFacade, IAllyFace
{
    private AllyFace(
            ITitleFacade titleFacade, 
            ICardTypeFacade cardTypeFacade, 
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IResourceGeneratorFacade resourceFacade,
            ICostFacade costFacade)
        : base(
            titleFacade, 
            cardTypeFacade, 
            classificationFacade) 
    {
        LifeItem = lifeFacade;
        ThwartItem = thwartFacade;
        AttackItem = attackFacade;
        ResourceItem = resourceFacade;
        CostItem = costFacade;
    }

    #region IThwartFacade

    private readonly IThwartFacade ThwartItem;
    public int Thwart => ThwartItem.Thwart;
    public void AddDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

    public void Register(Action<IThwartComponent> callback) => ThwartItem.Register(callback);
    public void UnRegister(Action<IThwartComponent> callback) => ThwartItem.UnRegister(callback);
    public void Notify(IThwartComponent data) => ThwartItem.Notify(data);

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

    #region ICostFacade

    private readonly ICostFacade CostItem;
    public int Cost => CostItem.Cost;
    public void AddDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.RemoveDecorator(decorator);

    public void Register(Action<ICostComponent> callback) => CostItem.Register(callback);
    public void UnRegister(Action<ICostComponent> callback) => CostItem.UnRegister(callback);
    public void Notify(ICostComponent data) => CostItem.Notify(data);

    #endregion

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;

    public int Energy => ResourceItem.Energy;
    public int Mental => ResourceItem.Mental;
    public int Physic => ResourceItem.Physic;
    public int Wild => ResourceItem.Wild;

    public void AddDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.RemoveDecorator(decorator);

    public void Register(Action<IResourceGeneratorComponent> callback) => ResourceItem.Register(callback);
    public void UnRegister(Action<IResourceGeneratorComponent> callback) => ResourceItem.UnRegister(callback);
    public void Notify(IResourceGeneratorComponent data) => ResourceItem.Notify(data);

    #endregion

    public static IAllyFace Get(AllyFaceModel faceModel)
        => new AllyFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            LifeFacade.Get(faceModel.Life),
            ThwartFacade.Get(faceModel.Thwart),
            AttackFacade.Get(faceModel.Attack),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostFacade.Get(faceModel.Cost));
}
