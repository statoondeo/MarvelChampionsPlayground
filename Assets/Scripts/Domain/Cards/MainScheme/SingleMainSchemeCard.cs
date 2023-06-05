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
            IAccelerationTokenFacade tokenAccelerationFacade,
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
    {
        TokeAccelerationItem = tokenAccelerationFacade;
        faceMediator.Register<IAccelerationTokenComponent>(TokeAccelerationItem);
        backMediator.Register<IAccelerationTokenComponent>(faceMediator.GetEventHandler<IAccelerationTokenComponent>());
        SetCard(this);
    }

    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        TokeAccelerationItem.SetCard(card);
    }

    #endregion

    #region IAccelerationTokenFacade

    private readonly IAccelerationTokenFacade TokeAccelerationItem;
    public void AddDecorator(ICardComponentDecorator<IAccelerationTokenComponent> decorator) => TokeAccelerationItem.AddDecorator(decorator);
    public void RemoveDecorator(ICardComponentDecorator<IAccelerationTokenComponent> decorator) => TokeAccelerationItem.RemoveDecorator(decorator);
    public int AccelerationToken => TokeAccelerationItem.AccelerationToken;

    #endregion

    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IAccelerationTokenFacade accelerationTokenFacade = AccelerationTokenFacade.Get(0);
        IMediator<ICardComponent> face1Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face2Mediator = CardComponentMediator.Get();
        return new SingleMainSchemeCard(
                    game,
                    CardTypeFacade.Get(CardType.MainScheme),
                    face1Mediator,
                    face2Mediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        MainSchemeAFace.Get(game, face1Mediator, accelerationTokenFacade, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(game, face2Mediator, accelerationTokenFacade, (MainSchemeBFaceModel)cardModel.Back)),
                    TapFacade.Get(),
                    accelerationTokenFacade,
                    LocationFacade.Get(string.Empty));
    }
}
