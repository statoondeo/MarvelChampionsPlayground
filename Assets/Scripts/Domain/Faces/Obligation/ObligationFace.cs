using System;

public sealed class ObligationFace : BaseFacade, IObligationFace
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

    #region Constructeur

    private ObligationFace(
            ITitleFacade titleFacade,
            ICardTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IBoostFacade boostFacade)
        : base(
            titleFacade,
            cardTypeFacade,
            classificationFacade)
        => BoostItem = boostFacade;

    #endregion

    #region Factory

    public static IObligationFace Get(ObligationFaceModel faceModel)
        => new ObligationFace(
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            CardTypeFacade.Get(faceModel.CardType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost));

    #endregion
}
