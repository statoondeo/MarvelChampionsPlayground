public class DoubleMainSchemeCard : BaseCard, IMainSchemeCard
{
    protected DoubleMainSchemeCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<ICardComponent> face1Mediator,
            IMediator<ICardComponent> face2Mediator,
            IMediator<ICardComponent> face3Mediator,
            IMediator<ICardComponent> face4Mediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game,
            cardTypeFacade,
            face1Mediator,
            face2Mediator,
            coreCardFacade,
            flipFacade,
            tapFacade,
            locationFacade)
    {
        face3Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face3Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face3Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face3Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face3Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());

        face4Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face4Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face4Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face4Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face4Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());
    }
    public static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<ICardComponent> face1Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face2Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face3Mediator = CardComponentMediator.Get();
        IMediator<ICardComponent> face4Mediator = CardComponentMediator.Get();
        return new DoubleMainSchemeCard(
                    game,
                    CardTypeFacade.Get(CardType.MainScheme),
                    face1Mediator,
                    face2Mediator,
                    face3Mediator,
                    face4Mediator,
                    CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                    FlipFacade.Get(
                        MainSchemeAFace.Get(face1Mediator, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(face2Mediator, (MainSchemeBFaceModel)cardModel.Back),
                        MainSchemeAFace.Get(face3Mediator, (MainSchemeAFaceModel)((DoubleMainSchemeCardModel)cardModel).FaceB),
                        MainSchemeBFace.Get(face4Mediator, (MainSchemeBFaceModel)((DoubleMainSchemeCardModel)cardModel).BackB)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
