public sealed class SingleMainSchemeCard : BaseCard, IMainSchemeCard
{
    private SingleMainSchemeCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<ICardComponent> faceMediator,
            IMediator<ICardComponent> backMediator,
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
            locationFacade)
    { }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<ICardComponent> face1Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face2Mediator = CardComponentMediator.Get();
        return new SingleMainSchemeCard(
                    game,
                    CardTypeFacade.Get(CardType.MainScheme),
                    face1Mediator,
                    face2Mediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        MainSchemeAFace.Get(face1Mediator, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(face2Mediator, (MainSchemeBFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
