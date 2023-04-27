public sealed class BasicAttachmentCard : BaseCard
{
    public BasicAttachmentCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            AttachmentCardModel cardModel)
        => new BasicAttachmentCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicAttachmentFace.Get((AttachmentFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
