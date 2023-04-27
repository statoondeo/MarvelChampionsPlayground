public sealed class BasicVillainCard : BaseCard
{
    public BasicVillainCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            VillainCardModel cardModel)
        => new BasicVillainCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicVillainFace.Get((VillainFaceModel)cardModel.Face),
            BasicVillainFace.Get((VillainFaceModel)cardModel.Back));
}