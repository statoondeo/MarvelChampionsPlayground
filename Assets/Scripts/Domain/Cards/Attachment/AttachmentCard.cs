public sealed class AttachmentCard : BaseCard, IAttachmentCard
{
    private AttachmentCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<IComponent> faceMediator,
            IMediator<IComponent> backMediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            cardTypeFacade,
            faceMediator,
            backMediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            CardModel cardModel)
    {
        IMediator<IComponent> faceMediator = ComponentMediator.Get();
        IMediator<IComponent> backMediator = ComponentMediator.Get();
        return new AttachmentCard(
                    game,
                    CardTypeFacade.Get(CardType.Attachment),
                    faceMediator,
                    backMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        AttachmentFace.Get(faceMediator, (AttachmentFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
