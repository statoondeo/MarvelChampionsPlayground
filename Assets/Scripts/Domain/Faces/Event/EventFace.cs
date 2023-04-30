using System;

public sealed class EventFace : BaseFacade, IEventFace
{
    #region ICostFacade

    private readonly ICostFacade CostItem;
    ICostComponent IFacade<ICostComponent>.Item => CostItem.Item;
    Action<ICostComponent> IComponent<ICostComponent>.OnChanged
    { get => CostItem.OnChanged; set => CostItem.OnChanged = value; }
    int ICostComponent.Cost => CostItem.Cost;
    void IFacade<ICostComponent>.AddDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.AddDecorator(decorator);
    void IFacade<ICostComponent>.RemoveDecorator(IDecorator<ICostComponent> decorator) 
        => CostItem.RemoveDecorator(decorator);

    #endregion

    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;
    IResourceGeneratorComponent IFacade<IResourceGeneratorComponent>.Item => ResourceItem.Item;
    int IResourceGeneratorComponent.Energy => ResourceItem.Energy;
    int IResourceGeneratorComponent.Mental => ResourceItem.Mental;
    int IResourceGeneratorComponent.Physic => ResourceItem.Physic;
    int IResourceGeneratorComponent.Wild => ResourceItem.Wild;

    Action<IResourceGeneratorComponent> IComponent<IResourceGeneratorComponent>.OnChanged
    { get => ResourceItem.OnChanged; set => ResourceItem.OnChanged = value; }

    void IFacade<IResourceGeneratorComponent>.AddDecorator(IDecorator<IResourceGeneratorComponent> decorator) => ResourceItem.AddDecorator(decorator);
    void IFacade<IResourceGeneratorComponent>.RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator) => ResourceItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private EventFace(
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

    public static IEventFace Get(EventFaceModel faceModel)
        => new EventFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild),
            CostFacade.Get(faceModel.Cost));

    #endregion
}
