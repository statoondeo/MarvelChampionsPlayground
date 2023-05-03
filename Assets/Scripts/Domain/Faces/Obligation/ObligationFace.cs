using System;

public sealed class ObligationFace : CoreFacade, IObligationFace
{
    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void Register(Action<IBoostComponent> callback) => BoostItem.Register(callback);
    public void UnRegister(Action<IBoostComponent> callback) => BoostItem.UnRegister(callback);
    public void Notify(IBoostComponent data) => BoostItem.Notify(data);
    public void AddDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator)
        => BoostItem.RemoveDecorator(decorator);

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
