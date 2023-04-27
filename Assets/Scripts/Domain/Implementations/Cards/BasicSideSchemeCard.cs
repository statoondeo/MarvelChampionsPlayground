public sealed class BasicSideSchemeCard : BaseCard
{
    public BasicSideSchemeCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            SideSchemeCardModel cardModel)
        => new BasicSideSchemeCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicSideSchemeFace.Get((SideSchemeFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
