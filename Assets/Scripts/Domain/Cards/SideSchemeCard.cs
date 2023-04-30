public sealed class SideSchemeCard : BaseCard, ISideSchemeCard
{
    public SideSchemeCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new SideSchemeCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                SideSchemeFace.Get((SideSchemeFaceModel)cardModel.Face),
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface ISideSchemeCard : ICard { }