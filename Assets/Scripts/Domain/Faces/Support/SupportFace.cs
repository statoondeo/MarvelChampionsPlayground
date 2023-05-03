using System;

public sealed class SupportFace : CoreFacade, ISupportFace
{
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

    #region Constructeur

    private SupportFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IResourceGeneratorFacade resourceFacade,
            ICostFacade costFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        CostItem = costFacade;
        ResourceItem = resourceFacade;
    }

    #endregion

    #region Factory

    public static ISupportFace Get(SupportFaceModel faceModel)
        => new SupportFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostFacade.Get(faceModel.Cost));

    #endregion
}
