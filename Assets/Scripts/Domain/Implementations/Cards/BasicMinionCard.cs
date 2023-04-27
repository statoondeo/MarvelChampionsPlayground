public sealed class BasicMinionCard : BaseCard
{
    public BasicMinionCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            MinionCardModel cardModel)
        => new BasicMinionCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicMinionFace.Get((MinionFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
