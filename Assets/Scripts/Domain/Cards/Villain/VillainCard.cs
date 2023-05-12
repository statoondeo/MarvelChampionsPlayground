﻿public sealed class VillainCard : BaseCard, IVillainCard
{
    private VillainCard(
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
    public static ICard Get(
            IGame game,
            string id,
            string ownerId,
            CardModel cardModel)
    {
        IMediator<IComponent> faceMediator = ComponentMediator.Get();
        IMediator<IComponent> backMediator = ComponentMediator.Get();
        return new VillainCard(
                        game,
                        faceMediator,
                        backMediator,
                        CoreCardFacade.Get(cardModel.CardId, id, ownerId),
                        FlipFacade.Get(
                            VillainFace.Get(faceMediator, (VillainFaceModel)cardModel.Face),
                            VillainFace.Get(backMediator, (VillainFaceModel)cardModel.Back)),
                        TapFacade.Get(),
                        LocationFacade.Get(string.Empty));
    }
}
