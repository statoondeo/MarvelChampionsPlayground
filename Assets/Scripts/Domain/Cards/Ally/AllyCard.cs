public sealed class AllyCard : BaseCard, IAllyCard
{
    public AllyCard(IGame game, ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(game, coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new AllyCard(
            game,
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                AllyFace.Get((AllyFaceModel)cardModel.Face), 
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
