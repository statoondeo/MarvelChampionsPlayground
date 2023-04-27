public sealed class BasicObligationCard : BaseCard
{
    public BasicObligationCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            ObligationCardModel cardModel)
        => new BasicObligationCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicObligationFace.Get((ObligationFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
