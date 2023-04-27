public sealed class BasicSupportCard : BaseCard
{
    public BasicSupportCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            SupportCardModel cardModel)
        => new BasicEventCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicSupportFace.Get((SupportFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
