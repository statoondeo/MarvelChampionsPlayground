//public interface IAllyFacade : IFacade<IAllyFace>, IAllyFace { }
public sealed class AllyFacade : BaseFacade, IAllyFacade
{
    private AllyFacade(
            ITitleFacade titleFacade, 
            ICardTypeFacade cardTypeFacade, 
            IClassificationFacade classificationFacade,
            ILifeFacade lifeFacade,
            IThwartFacade thwartFacade,
            IAttackFacade attackFacade,
            IResourceFacade resourceFacade,
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
    IThwart IFacade<IThwart>.Item => ThwartItem.Item;
    int IThwart.Thwart => ThwartItem.Thwart;
    void IFacade<IThwart>.AddDecorator(IDecorator<IThwart> decorator) => ThwartItem.AddDecorator(decorator);
    void IFacade<IThwart>.RemoveDecorator(IDecorator<IThwart> decorator) => ThwartItem.RemoveDecorator(decorator);

    #endregion

    #region IAttackFacade

    private readonly IAttackFacade AttackItem;
    IAttack IFacade<IAttack>.Item => AttackItem.Item;
    int IAttack.Attack => AttackItem.Attack;
    void IFacade<IAttack>.AddDecorator(IDecorator<IAttack> decorator) => AttackItem.AddDecorator(decorator);
    void IFacade<IAttack>.RemoveDecorator(IDecorator<IAttack> decorator) => AttackItem.RemoveDecorator(decorator);

    #endregion

    #region ILifeFacade

    private readonly ILifeFacade LifeItem;
    ILife IFacade<ILife>.Item => LifeItem.Item;
    int ILife.Life => LifeItem.Life;
    void IFacade<ILife>.AddDecorator(IDecorator<ILife> decorator) => LifeItem.AddDecorator(decorator);
    void IFacade<ILife>.RemoveDecorator(IDecorator<ILife> decorator) => LifeItem.RemoveDecorator(decorator);

    #endregion

    #region ICostFacade

    private readonly ICostFacade CostItem;
    ICost IFacade<ICost>.Item => CostItem.Item;
    int ICost.Cost => CostItem.Cost;
    void IFacade<ICost>.AddDecorator(IDecorator<ICost> decorator) => CostItem.AddDecorator(decorator);
    void IFacade<ICost>.RemoveDecorator(IDecorator<ICost> decorator) => CostItem.RemoveDecorator(decorator);

    #endregion

    #region IResourceFacade

    private readonly IResourceFacade ResourceItem;
    IResource IFacade<IResource>.Item => ResourceItem.Item;
    int IResource.Energy => ResourceItem.Energy;
    int IResource.Mental => ResourceItem.Mental;
    int IResource.Physic => ResourceItem.Physic;
    int IResource.Wild => ResourceItem.Wild;
    void IFacade<IResource>.AddDecorator(IDecorator<IResource> decorator) => ResourceItem.AddDecorator(decorator);
    void IFacade<IResource>.RemoveDecorator(IDecorator<IResource> decorator) => ResourceItem.RemoveDecorator(decorator);

    #endregion

    public static IAllyFacade Get(AllyFaceModel faceModel)
        => new AllyFacade(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            LifeFacade.Get(faceModel.Life),
            ThwartFacade.Get(faceModel.Thwart),
            AttackFacade.Get(faceModel.Attack),
            ResourceFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostFacade.Get(faceModel.Cost));
}



//public sealed class BasicAllyFace : BaseFace, IAllyFace
//{
//    #region ILife

//    private readonly ILife LifeBrick;
//    public int Life => LifeBrick.Life;

//    #endregion

//    #region IThwart

//    private readonly IThwart ThwartBrick;
//    public int Thwart => ThwartBrick.Thwart;

//    #endregion

//    #region IAttack

//    private readonly IAttack AttackBrick;
//    public int Attack => AttackBrick.Attack;

//    #endregion

//    #region IResource

//    private readonly IResource ResourceBrick;
//    public int Energy => ResourceBrick.Energy;
//    public int Mental => ResourceBrick.Mental;
//    public int Physic => ResourceBrick.Physic;
//    public int Wild => ResourceBrick.Wild;

//    #endregion

//    #region ICost

//    private ICost CostBrick;
//    public int Cost => CostBrick.Cost;

//    #endregion

//    #region Constructeur 

//    private BasicAllyFace(
//            ITitle titleComponent,
//            ICardType cardTypeComponent,
//            IClassification classificationComponent,
//            ILife lifeComponent,
//            IThwart thwartComponent,
//            IAttack attackComponent,
//            IResource resourceComponent,
//            ICost costComponent)
//        : base(
//            titleComponent,
//            cardTypeComponent,
//            classificationComponent)
//    {
//        LifeBrick = lifeComponent;
//        ThwartBrick = thwartComponent;
//        AttackBrick = attackComponent;
//        ResourceBrick = resourceComponent;
//        CostBrick = costComponent;
//    }

//    #endregion

//    #region Factory

//    public static IAllyFace Get(AllyFaceModel faceModel)
//        => new BasicAllyFace(
//            TitleComponent.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
//            CardTypeComponent.Get(faceModel.CardType),
//            ClassificationComponent.Get(faceModel.Classification),
//            LifeComponent.Get(faceModel.Life),
//            ThwartComponent.Get(faceModel.Thwart),
//            AttackComponent.Get(faceModel.Attack),
//            ResourceComponent.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
//            CostComponent.Get(faceModel.Cost));

//    #endregion
//}
