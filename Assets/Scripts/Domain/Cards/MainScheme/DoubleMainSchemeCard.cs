﻿public sealed class DoubleMainSchemeCard : BaseCard, IMainSchemeCard
{
    private DoubleMainSchemeCard(
            IGame game,
            ICardTypeFacade cardTypeFacade,
            IMediator<ICardComponent> face1Mediator,
            IMediator<ICardComponent> face2Mediator,
            IMediator<ICardComponent> face3Mediator,
            IMediator<ICardComponent> face4Mediator,
            ICoreCardFacade coreCardFacade,
            IFlipFacade flipFacade,
            IAccelerationTokenFacade tokenAccelerationFacade,
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
        TokeAccelerationItem = tokenAccelerationFacade;
        face1Mediator.Register<IAccelerationTokenComponent>(TokeAccelerationItem);
        face2Mediator.Register<IAccelerationTokenComponent>(face1Mediator.GetEventHandler<IAccelerationTokenComponent>());

        face3Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face3Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face3Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face3Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face3Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());
        face3Mediator.Register<IAccelerationTokenComponent>(face1Mediator.GetEventHandler<IAccelerationTokenComponent>());

        face4Mediator.Register<ICardTypeComponent>(face1Mediator.GetEventHandler<ICardTypeComponent>());
        face4Mediator.Register<ICoreCardComponent>(face1Mediator.GetEventHandler<ICoreCardComponent>());
        face4Mediator.Register<IFlipComponent>(face1Mediator.GetEventHandler<IFlipComponent>());
        face4Mediator.Register<ITapComponent>(face1Mediator.GetEventHandler<ITapComponent>());
        face4Mediator.Register<ILocationComponent>(face1Mediator.GetEventHandler<ILocationComponent>());
        face4Mediator.Register<IAccelerationTokenComponent>(face1Mediator.GetEventHandler<IAccelerationTokenComponent>());

        SetCard(this);
    }

    #region ICardHolder

    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        TokeAccelerationItem.SetCard(card);
    }

    #endregion

    #region ILifeFacade

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
                        MainSchemeAFace.Get(game, face1Mediator, accelerationTokenFacade, (MainSchemeAFaceModel)cardModel.Face),
                        MainSchemeBFace.Get(game, face2Mediator, accelerationTokenFacade, (MainSchemeBFaceModel)cardModel.Back),
                        MainSchemeAFace.Get(game, face3Mediator, accelerationTokenFacade, (MainSchemeAFaceModel)((DoubleMainSchemeCardModel)cardModel).FaceB),
                        MainSchemeBFace.Get(game, face4Mediator, accelerationTokenFacade, (MainSchemeBFaceModel)((DoubleMainSchemeCardModel)cardModel).BackB)),
                    accelerationTokenFacade,
                    TapFacade.Get(),
                    LocationFacade.Get(string.Empty));
    }
}
