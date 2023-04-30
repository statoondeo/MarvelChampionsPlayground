using System;

public sealed class AttachmentFace : BaseFacade, IAttachmentFace
{
    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    IBoostComponent IFacade<IBoostComponent>.Item => BoostItem.Item;
    int IBoostComponent.Boost => BoostItem.Boost;
    Action<IBoostComponent> IComponent<IBoostComponent>.OnChanged
    { get => BoostItem.OnChanged; set => BoostItem.OnChanged = value; }
    void IFacade<IBoostComponent>.AddDecorator(IDecorator<IBoostComponent> decorator) 
        => BoostItem.AddDecorator(decorator);
    void IFacade<IBoostComponent>.RemoveDecorator(IDecorator<IBoostComponent> decorator) 
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    IWhenRevealedComponent IFacade<IWhenRevealedComponent>.Item => WhenRevealedItem.Item;
    ICommand IWhenRevealedComponent.WhenRevealed => WhenRevealedItem.WhenRevealed;

    Action<IWhenRevealedComponent> IComponent<IWhenRevealedComponent>.OnChanged 
    { get => WhenRevealedItem.OnChanged; set => WhenRevealedItem.OnChanged = value; }

    void IFacade<IWhenRevealedComponent>.AddDecorator(IDecorator<IWhenRevealedComponent> decorator) 
        => WhenRevealedItem.AddDecorator(decorator);
    void IFacade<IWhenRevealedComponent>.RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) 
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private AttachmentFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IBoostFacade boostFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;
    }

    #endregion

    #region Factory

    public static IAttachmentFace Get(AttachmentFaceModel faceModel)
        => new AttachmentFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}
