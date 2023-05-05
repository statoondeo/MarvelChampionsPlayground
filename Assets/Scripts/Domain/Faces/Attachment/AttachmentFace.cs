public sealed class AttachmentFace : CoreFacade, IAttachmentFace
{
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #region IBoostFacade

    private readonly IBoostFacade BoostItem;
    public int Boost => BoostItem.Boost;
    public void AddDecorator(IDecorator<IBoostComponent> decorator) 
        => BoostItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IBoostComponent> decorator) 
        => BoostItem.RemoveDecorator(decorator);

    #endregion

    #region IWhenRevealedFacade

    private readonly IWhenRevealedFacade WhenRevealedItem;
    public ICommand WhenRevealed => WhenRevealedItem.WhenRevealed;
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator) 
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) 
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
