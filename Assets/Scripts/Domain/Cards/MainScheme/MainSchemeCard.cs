public sealed class MainSchemeCard : BaseCard, IMainSchemeCard
{
    public MainSchemeCard(IGame game, ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(game, coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new MainSchemeCard(
            game,
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                MainSchemeAFace.Get((MainSchemeAFaceModel)cardModel.Face),
                MainSchemeBFace.Get((MainSchemeBFaceModel)cardModel.Back)),
            TapFacade.Get());
}
