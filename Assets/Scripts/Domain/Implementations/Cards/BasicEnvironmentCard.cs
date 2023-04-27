public sealed class BasicEnvironmentCard : BaseCard
{
    public BasicEnvironmentCard(IGame game, string cardId, string id, string ownerId, IFace face, IFace back)
        : base(game, cardId, id, ownerId, face, back) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            EnvironmentCardModel cardModel)
        => new BasicEnvironmentCard(
            game,
            cardModel.CardId,
            id,
            ownerId,
            BasicEnvironmentFace.Get((EnvironmentFaceModel)cardModel.Face),
            BasicBackFace.Get((BackFaceModel)cardModel.Back));
}
