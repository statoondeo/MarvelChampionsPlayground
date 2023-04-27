public sealed class BasicEventCard : BaseCard
{
    public BasicEventCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            EventCardModel cardModel)
        => new BasicEventCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicEventFace.Get((EventFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
