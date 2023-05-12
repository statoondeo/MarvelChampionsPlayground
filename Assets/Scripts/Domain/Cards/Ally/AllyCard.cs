public sealed class AllyCard : BaseCard, IAllyCard
{
    private AllyCard(
            IGame game,
            IMediator<IComponent> faceMediator,
            IMediator<IComponent> backMediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            faceMediator,
            backMediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            CardModel cardModel)
    {
        IMediator<IComponent> faceMediator = ComponentMediator.Get();
        IMediator<IComponent> backMediator = ComponentMediator.Get();
        return new AllyCard(
                    game,
                    faceMediator,
                    backMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        AllyFace.Get(faceMediator, (AllyFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
