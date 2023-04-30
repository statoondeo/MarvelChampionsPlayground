public sealed class ObligationCard : BaseCard, IObligationCard
{
    public ObligationCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new ObligationCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                ObligationFace.Get((ObligationFaceModel)cardModel.Face),
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface IObligationCard : ICard { }