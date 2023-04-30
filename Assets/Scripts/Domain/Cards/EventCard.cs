public sealed class EventCard : BaseCard, IEventCard
{
    public EventCard(ICoreCardFacade coreCardFacade, IFlipFacade flipFacade, ITapFacade tapFacade)
        : base(coreCardFacade, flipFacade, tapFacade) { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
        => new EventCard(
            CoreCardFacade.Get(cardModel.CardId, id, ownerId, game),
            FlipFacade.Get(
                EventFace.Get((EventFaceModel)cardModel.Face),
                BackFace.Get((BackFaceModel)cardModel.Back)),
            TapFacade.Get());
}
public interface IEventCard : ICard { }