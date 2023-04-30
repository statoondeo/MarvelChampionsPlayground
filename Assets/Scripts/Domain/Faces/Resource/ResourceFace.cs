using System;

public sealed class ResourceFace : BaseFacade, IResourceFace
{
    #region IResourceFacade

    private readonly IResourceGeneratorFacade ResourceItem;
    IResourceGeneratorComponent IFacade<IResourceGeneratorComponent>.Item => ResourceItem.Item;
    int IResourceGeneratorComponent.Energy => ResourceItem.Energy;
    int IResourceGeneratorComponent.Mental => ResourceItem.Mental;
    int IResourceGeneratorComponent.Physic => ResourceItem.Physic;
    int IResourceGeneratorComponent.Wild => ResourceItem.Wild;
    void IFacade<IResourceGeneratorComponent>.AddDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.AddDecorator(decorator);
    void IFacade<IResourceGeneratorComponent>.RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator) 
        => ResourceItem.RemoveDecorator(decorator);
    Action<IResourceGeneratorComponent> IComponent<IResourceGeneratorComponent>.OnChanged
    { get => ResourceItem.OnChanged; set => ResourceItem.OnChanged = value; }

    #endregion

    #region Constructeur

    private ResourceFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IResourceGeneratorFacade resourceFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade) 
        => ResourceItem = resourceFacade;

    #endregion

    #region Factory

    public static IResourceFace Get(ResourceFaceModel faceModel)
        => new ResourceFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            ResourceGeneratorFacade.Get(faceModel.Energy, faceModel.Mental, faceModel.Physic, faceModel.Wild));

    #endregion
}
