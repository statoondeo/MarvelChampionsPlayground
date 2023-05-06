﻿public sealed class SideSchemeCard : BaseCard, ISideSchemeCard
{
    private SideSchemeCard(
            IGame game,
            ICardMediator mediator,
            ICoreCardFacade coreCardFacade, 
            IFlipFacade flipFacade,
            ITapFacade tapFacade,
            ILocationFacade locationFacade)
        : base(
            game, 
            mediator, 
            coreCardFacade, 
            flipFacade, 
            tapFacade,
            locationFacade)
    {
        Card.Register(ComponentType.Location, OnBattlefieldCallback);
        Card.Register(ComponentType.Flip, OnBattlefieldCallback);
    }
    private void OnBattlefieldCallback(ICard card)
    {
        if (card.IsLocation("BATTLEFIELD") && card.IsFace("FACE"))
            card.Tap();
        else
            card.UnTap();
    }
    public static ICard Get(
            IGame game, 
            string id, 
            string ownerId, 
            CardModel cardModel) 
        => new SideSchemeCard(
                game,
                CardMediator.Get(),
                CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                FlipFacade.Get(
                    SideSchemeFace.Get((SideSchemeFaceModel)cardModel.Face),
                    BackFace.Get((BackFaceModel)cardModel.Back)),
                TapFacade.Get(),
                LocationFacade.Get(string.Empty));
}
