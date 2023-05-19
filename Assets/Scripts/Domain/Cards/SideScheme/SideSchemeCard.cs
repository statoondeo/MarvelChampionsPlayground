public sealed class SideSchemeCard : BaseCard, ISideSchemeCard
{
    private SideSchemeCard(
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
            locationFacade) { }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            CardModel cardModel)
    {
        IMediator<ICardComponent> faceMediator = CardComponentMediator.Get();
        IMediator<ICardComponent> backMediator = CardComponentMediator.Get();
        return new SideSchemeCard(
                    game,
                    CardTypeFacade.Get(CardType.SideScheme),
                    faceMediator,
                    backMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        SideSchemeFace.Get(faceMediator, (SideSchemeFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
