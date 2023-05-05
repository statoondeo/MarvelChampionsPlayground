public sealed class MainSchemeCard : BaseCard, IMainSchemeCard
{
    private MainSchemeCard(
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
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel) 
        => new MainSchemeCard(
                game,
                CardMediator.Get(),
                CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                FlipFacade.Get(
                    MainSchemeAFace.Get((MainSchemeAFaceModel)cardModel.Face),
                    MainSchemeBFace.Get((MainSchemeBFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LocationFacade.Get(string.Empty));
}
