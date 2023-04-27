public sealed class BasicMainSchemeCard : BaseCard
{
    public BasicMainSchemeCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            MainSchemeCardModel cardModel)
        => new BasicMainSchemeCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicMainSchemeAFace.Get((MainSchemeAFaceModel)cardModel.Face),
            BasicMainSchemeBFace.Get((MainSchemeBFaceModel)cardModel.Back));
}
