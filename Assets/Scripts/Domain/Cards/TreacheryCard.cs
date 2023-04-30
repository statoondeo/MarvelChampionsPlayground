public sealed class TreacheryCard : BaseCard, ITreacheryCard
{
    public TreacheryCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new TreacheryCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                TreacheryFace.Get((TreacheryFaceModel)cardModel.Face),
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface ITreacheryCard : ICard { }