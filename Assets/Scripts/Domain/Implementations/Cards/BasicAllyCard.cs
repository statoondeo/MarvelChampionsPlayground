public sealed class BasicAllyCard : BaseCard
{
    public BasicAllyCard(IGame game, string cardIId, string id, string ownerId, IFacade face, IFacade back)
        : base(game, cardIId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            AllyCardModel cardModel)
        => new BasicAllyCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            AllyFacade.Get((AllyFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
