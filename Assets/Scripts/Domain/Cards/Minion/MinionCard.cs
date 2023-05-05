public sealed class MinionCard : BaseCard, IMinionCard
{
    public MinionCard(
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
        => new MinionCard(
                game,
                CardMediator.Get(),
                CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                FlipFacade.Get(
                    MinionFace.Get((MinionFaceModel)cardModel.Face),
                    BackFace.Get((BackFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LocationFacade.Get(string.Empty));
}
