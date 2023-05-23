public sealed class TripleMainSchemeCard : DoubleMainSchemeCard, IMainSchemeCard
{
    private TripleMainSchemeCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<ICardComponent> face1Mediator,
            IMediator<ICardComponent> face2Mediator,
            IMediator<ICardComponent> face3Mediator,
            IMediator<ICardComponent> face4Mediator,
            IMediator<ICardComponent> face5Mediator,
            IMediator<ICardComponent> face6Mediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            cardTypeFacade,
            face1Mediator,
            face2Mediator,
            face3Mediator,
            face4Mediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    {
        face5Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face5Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face5Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face5Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face5Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());

        face6Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face6Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face6Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face6Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face6Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());

        SetCard(this);
    }
    public new static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<ICardComponent> face1Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face2Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face3Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face4Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face5Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face6Mediator = CardComponentMediator.Get();
        return new TripleMainSchemeCard(
                    game,
                    CardTypeFacade.Get(CardType.MainScheme),
                    face1Mediator,
                    face2Mediator,
                    face3Mediator,
                    face4Mediator,
                    face5Mediator,
                    face6Mediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        MainSchemeAFace.Get(game, face1Mediator, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(face2Mediator, (MainSchemeBFaceModel)cardModel.Back),
                        MainSchemeAFace.Get(game, face3Mediator, (MainSchemeAFaceModel)((TripleMainSchemeCardModel)cardModel).FaceB),
                        MainSchemeBFace.Get(face4Mediator, (MainSchemeBFaceModel)((TripleMainSchemeCardModel)cardModel).BackB),
                        MainSchemeAFace.Get(game, face5Mediator, (MainSchemeAFaceModel)((TripleMainSchemeCardModel)cardModel).FaceC),
                        MainSchemeBFace.Get(face6Mediator, (MainSchemeBFaceModel)((TripleMainSchemeCardModel)cardModel).BackC)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
