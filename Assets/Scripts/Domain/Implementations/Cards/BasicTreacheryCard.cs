public sealed class BasicTreacheryCard : BaseCard
{
    public BasicTreacheryCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            TreacheryCardModel cardModel)
        => new BasicTreacheryCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicTreacheryFace.Get((TreacheryFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
