public sealed class BasicResourceCard : BaseCard
{
    public BasicResourceCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            ResourceCardModel cardModel)
        => new BasicResourceCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicResourceFace.Get((ResourceFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
