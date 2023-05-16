public sealed class EnvironmentCard : BaseCard, IEnvironmentCard
{
    private EnvironmentCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<IComponent> faceMediator,
            IMediator<IComponent> backMediator,
            ICoreCardFacade coreCardFacade, 
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            cardTypeFacade,
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
        return new EnvironmentCard(
                    game,
                    CardTypeFacade.Get(CardType.Environment),
                    faceMediator,
                    backMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        EnvironmentFace.Get(faceMediator, (EnvironmentFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
