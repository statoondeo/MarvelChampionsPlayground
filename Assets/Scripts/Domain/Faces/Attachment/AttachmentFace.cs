﻿public sealed class AttachmentFace : BaseFace, IAttachmentFace
{
    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        BoostItem.SetCard(card);
        WhenRevealedItem.SetCard(card);
    }

    #endregion

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
    public void Reveal() => WhenRevealedItem.Reveal();
    public void AddDecorator(IDecorator<IWhenRevealedComponent> decorator) 
        => WhenRevealedItem.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IWhenRevealedComponent> decorator) 
        => WhenRevealedItem.RemoveDecorator(decorator);

    #endregion

    #region Constructeur

    private AttachmentFace(
            IMediator<IComponent> mediator,
            ITitleFacade titleFacade,
            IFaceTypeFacade cardTypeFacade,
            IClassificationFacade classificationFacade,
            IBoostFacade boostFacade,
            IWhenRevealedFacade whenRevealedFacade)
        : base(
            mediator,
            titleFacade,
            cardTypeFacade,
            classificationFacade)
    {
        BoostItem = boostFacade;
        WhenRevealedItem = whenRevealedFacade;

        Mediator.Register<IBoostComponent>(BoostItem);
        Mediator.Register<IWhenRevealedComponent>(WhenRevealedItem);
    }

    #endregion

    #region Factory

    public static IAttachmentFace Get(IMediator<IComponent> mediator, AttachmentFaceModel faceModel)
        => new AttachmentFace(
            mediator,
            TitleFacade.Get(faceModel.Title, faceModel.SubTitle, faceModel.Sprite),
            FaceTypeFacade.Get(faceModel.FaceType),
            ClassificationFacade.Get(faceModel.Classification),
            BoostFacade.Get(faceModel.Boost),
            WhenRevealedFacade.Get(PermanentWhenRevealedComponent.Get(NullCommand.Get())));

    #endregion
}
