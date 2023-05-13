public sealed class SingleMainSchemeCard : BaseCard, IMainSchemeCard
{
    private SingleMainSchemeCard(
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
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IFlipComponent>(OnCardChanged);
        Card.AddListener<ILocationComponent>(OnCardChanged);
    }
    private void OnCardChanged(IComponent component)
    {
        if (Card.IsLocation("BATTLEFIELD"))
        {
            Card.Tap();
            return;
        }
        Card.UnTap();
    }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<IComponent> face1Mediator = ComponentMediator.Get();
        IMediator<IComponent> face2Mediator = ComponentMediator.Get();
        return new SingleMainSchemeCard(
                    game,
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
