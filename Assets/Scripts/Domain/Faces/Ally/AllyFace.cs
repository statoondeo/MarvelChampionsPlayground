﻿public sealed class AllyFace : BaseFace, IAllyFace
{
    #region Constructor

    private AllyFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade, 
            ICardTypeFacade cardTypeFacade, 
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IResourceGeneratorFacade resourceFacade,
            IResetFacade resetFacade,
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
        ResetItem = resetFacade;

        Mediator.Register<ILifeComponent>(LifeItem);
        Mediator.Register<IThwartComponent>(ThwartItem);
        Mediator.Register<IAttackComponent>(AttackItem);
        Mediator.Register<IResourceGeneratorComponent>(ResourceItem);
        Mediator.Register<ICostComponent>(CostItem);
        Mediator.Register<IResetComponent>(ResetItem);
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
        ResetItem.SetCard(card);
        ResourceItem.SetCard(card);
    }

    #endregion

    #region IThwartFacade

    private readonly IThwartFacade ThwartItem;
    public int Thwart => ThwartItem.Thwart;
    public void AddDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IThwartComponent> decorator) => ThwartItem.RemoveDecorator(decorator);

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

    #region ICostFacade

    private readonly ICostFacade CostItem;
    public int Cost => CostItem.Cost;
    public void AddDecorator(IDecorator<ICostComponent> decorator)
        => CostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICostComponent> decorator)
        => CostItem.RemoveDecorator(decorator);

    #endregion

    #region IResetFacade

    private readonly IResetFacade ResetItem;
    public void Reset() => ResetItem.Reset();
    public void AddDecorator(IDecorator<IResetComponent> decorator)
        => ResetItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResetComponent> decorator)
        => ResetItem.RemoveDecorator(decorator);

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

    #endregion

    #region Factory

    public static IFace Get(IMediator<IComponent> mediator, AllyFaceModel faceModel)
    {
        return new AllyFace(
                mediator,
                TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
                CardTypeFacade.Get(faceModel.CardType),
                ClassificationFacade.Get(faceModel.Classification),
                LifeFacade.Get(faceModel.Life),
                ThwartFacade.Get(faceModel.Thwart),
                AttackFacade.Get(faceModel.Attack),
                ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
                ResetFacade.Get(BasicResetComponent.Get()),
                CostFacade.Get(faceModel.Cost));
    }

    #endregion
}
