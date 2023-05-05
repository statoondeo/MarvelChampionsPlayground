public sealed class AttachmentCard : BaseCard, IAttachmentCard
{
    private AttachmentCard(
            IGame game,
            ICardMediator mediator,
            ICoreCardFacade coreCardFacade, 
            IFlipFacade flipFacade, 
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game, 
            mediator,
            coreCardFacade, 
            flipFacade, 
            tapFacade,
            locationFacade) { }
    public static ICard Get(
            IGame game, 
            string id, 
            string ownerId, 
            CardModel cardModel) 
        => new AttachmentCard(
                game,
                CardMediator.Get(),
                CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                FlipFacade.Get(
                    AttachmentFace.Get((AttachmentFaceModel)cardModel.Face),
                    BackFace.Get((BackFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LocationFacade.Get(string.Empty));
}
