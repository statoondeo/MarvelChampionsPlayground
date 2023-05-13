public sealed class SideSchemeCard : BaseCard, ISideSchemeCard
{
    private SideSchemeCard(
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
        if (!Card.IsLocation("BATTLEFIELD"))
        {
            Card.UnTap();
            return;
        }
        if (!Card.IsFace("FACE")) return;
        Card.Tap();
        (Card as ITreatComponent)?.Init();
    }
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            CardModel cardModel)
    {
        IMediator<IComponent> faceMediator = ComponentMediator.Get();
        IMediator<IComponent> backMediator = ComponentMediator.Get();
        return new SideSchemeCard(
                    game,
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
