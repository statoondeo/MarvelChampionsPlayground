using System;

public sealed class AllyFace : BaseFacade, IAllyFace
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
    IThwartComponent IFacade<IThwartComponent>.Item => ThwartItem.Item;
    int IThwartComponent.Thwart => ThwartItem.Thwart;
    void IFacade<IThwartComponent>.AddDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    void IFacade<IThwartComponent>.RemoveDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

    Action<IThwartComponent> IComponent<IThwartComponent>.OnChanged { get => ThwartItem.OnChanged; set => ThwartItem.OnChanged = value; }

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    IAttackComponent IFacade<IAttackComponent>.Item => AttackItem.Item;
    int IAttackComponent.Attack => AttackItem.Attack;
    void IFacade<IAttackComponent>.AddDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.AddDecorator(decorator);
    void IFacade<IAttackComponent>.RemoveDecorator(IDecorator<IAttackComponent> decorator) => AttackItem.RemoveDecorator(decorator);

    Action<IAttackComponent> IComponent<IAttackComponent>.OnChanged { get => AttackItem.OnChanged; set => AttackItem.OnChanged = value; }

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    ILifeComponent IFacade<ILifeComponent>.Item => LifeItem.Item;
    int ILifeComponent.Life => LifeItem.Life;
    void IFacade<ILifeComponent>.AddDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.AddDecorator(decorator);
    void IFacade<ILifeComponent>.RemoveDecorator(IDecorator<ILifeComponent> decorator) => LifeItem.RemoveDecorator(decorator);

    Action<ILifeComponent> IComponent<ILifeComponent>.OnChanged 
    { get => LifeItem.OnChanged; set => LifeItem.OnChanged = value; }

    #endregion

    #region ICostFacade

    private readonly ICostFacade CostItem;
    ICostComponent IFacade<ICostComponent>.Item => CostItem.Item;
    int ICostComponent.Cost => CostItem.Cost;
    void IFacade<ICostComponent>.AddDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.AddDecorator(decorator);
    void IFacade<ICostComponent>.RemoveDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.RemoveDecorator(decorator);

    Action<ICostComponent> IComponent<ICostComponent>.OnChanged 
    { get => CostItem.OnChanged; set => CostItem.OnChanged = value; }

    #endregion

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;
    IResourceGeneratorComponent IFacade<IResourceGeneratorComponent>.Item 
        => ResourceItem.Item;
    int IResourceGeneratorComponent.Energy => ResourceItem.Energy;
    int IResourceGeneratorComponent.Mental => ResourceItem.Mental;
    int IResourceGeneratorComponent.Physic => ResourceItem.Physic;
    int IResourceGeneratorComponent.Wild => ResourceItem.Wild;

    Action<IResourceGeneratorComponent> IComponent<IResourceGeneratorComponent>.OnChanged 
    { get => ResourceItem.OnChanged; set => ResourceItem.OnChanged = value; }

    void IFacade<IResourceGeneratorComponent>.AddDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.AddDecorator(decorator);
    void IFacade<IResourceGeneratorComponent>.RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.RemoveDecorator(decorator);

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
