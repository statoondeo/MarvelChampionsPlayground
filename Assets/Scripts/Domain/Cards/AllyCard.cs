public sealed class AllyCard : BaseCard, IAllyCard
{
    public AllyCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new AllyCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                AllyFace.Get((AllyFaceModel)cardModel.Face), 
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface IAllyCard : ICard { }