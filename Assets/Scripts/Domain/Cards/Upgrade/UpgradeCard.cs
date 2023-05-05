public sealed class UpgradeCard : BaseCard, IUpgradeCard
{
    private UpgradeCard(
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
        => new UpgradeCard(
                game,
                CardMediator.Get(),
                CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                FlipFacade.Get(
                    UpgradeFace.Get((UpgradeFaceModel)cardModel.Face),
                    BackFace.Get((BackFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LocationFacade.Get(string.Empty));
}
