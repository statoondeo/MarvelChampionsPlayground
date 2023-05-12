public sealed class ObligationCard : BaseCard, IObligationCard
{
    private ObligationCard(
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
        return new ObligationCard(
                    game,
                    faceMediator,
                    faceMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        ObligationFace.Get(faceMediator, (ObligationFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
