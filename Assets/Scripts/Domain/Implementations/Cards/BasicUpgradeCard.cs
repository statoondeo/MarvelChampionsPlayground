public sealed class BasicUpgradeCard : BaseCard
{
    public BasicUpgradeCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            UpgradeCardModel cardModel)
        => new BasicUpgradeCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicUpgradeFace.Get((UpgradeFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
