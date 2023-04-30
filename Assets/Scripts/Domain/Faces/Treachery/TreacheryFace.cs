using System;

public sealed class TreacheryFace : BaseFacade, ITreacheryFace
{
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

    private TreacheryFace(
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

    public static ITreacheryFace Get(TreacheryFaceModel faceModel)
        => new TreacheryFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(NullCommand.Get()));

    #endregion
}
