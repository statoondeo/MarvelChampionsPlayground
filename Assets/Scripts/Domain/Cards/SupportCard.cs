public sealed class SupportCard : BaseCard, ISupportCard
{
    public SupportCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new SupportCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                SupportFace.Get((SupportFaceModel)cardModel.Face),
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface ISupportCard : ICard { }