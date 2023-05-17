﻿public sealed class TripleMainSchemeCard : DoubleMainSchemeCard, IMainSchemeCard
{
    private TripleMainSchemeCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<IComponent> face1Mediator,
            IMediator<IComponent> face2Mediator,
            IMediator<IComponent> face3Mediator,
            IMediator<IComponent> face4Mediator,
            IMediator<IComponent> face5Mediator,
            IMediator<IComponent> face6Mediator,
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
    }
    public new static ICard Get(IGame game, string id, string ownerId, CardModel cardModel)
    {
        IMediator<IComponent> face1Mediator = ComponentMediator.Get();
        IMediator<IComponent> face2Mediator = ComponentMediator.Get();
        IMediator<IComponent> face3Mediator = ComponentMediator.Get();
        IMediator<IComponent> face4Mediator = ComponentMediator.Get();
        IMediator<IComponent> face5Mediator = ComponentMediator.Get();
        IMediator<IComponent> face6Mediator = ComponentMediator.Get();
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
                        MainSchemeAFace.Get(face1Mediator, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(face2Mediator, (MainSchemeBFaceModel)cardModel.Back),
                        MainSchemeAFace.Get(face3Mediator, (MainSchemeAFaceModel)((TripleMainSchemeCardModel)cardModel).FaceB),
                        MainSchemeBFace.Get(face4Mediator, (MainSchemeBFaceModel)((TripleMainSchemeCardModel)cardModel).BackB),
                        MainSchemeAFace.Get(face5Mediator, (MainSchemeAFaceModel)((TripleMainSchemeCardModel)cardModel).FaceC),
                        MainSchemeBFace.Get(face6Mediator, (MainSchemeBFaceModel)((TripleMainSchemeCardModel)cardModel).BackC)),
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
