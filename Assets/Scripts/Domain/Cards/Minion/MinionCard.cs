public sealed class MinionCard : BaseCard, IMinionCard
{
    public MinionCard(
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
        return new MinionCard(
                    game,
                    CardTypeFacade.Get(CardType.Minion),
                    faceMediator,
                    backMediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        MinionFace.Get(faceMediator, (MinionFaceModel)cardModel.Face),
                        BackFace.Get(backMediator, (BackFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
