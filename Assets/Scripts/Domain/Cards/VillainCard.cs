public sealed class VillainCard : BaseCard, IVillainCard
{
    public VillainCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new VillainCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                VillainFace.Get((VillainFaceModel)cardModel.Face),
                VillainFace.Get((VillainFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface IVillainCard : ICard { }