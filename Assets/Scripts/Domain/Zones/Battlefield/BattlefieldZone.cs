public sealed class BattlefieldZone : BaseZone, IBattlefieldZone
{
    private BattlefieldZone(
            IGame game,
            IMediator<IZoneComponent> mediator,
            ICoreZoneComponentFacade coreZoneFacade)
        : base(game, mediator, coreZoneFacade) => SetZone(this);
    public override void Add(ICard card)
    {
        base.Add(card);
        card.FlipTo(0);
        card.GetFacade<IEnterPlayComponent>()?.EnterPlay();
    }
    public static IBattlefieldZone Get(IGame game, string id, string label, string ownerId) 
        => new BattlefieldZone(
            game, 
            ZoneComponentMediator.Get(), 
            CoreZoneComponentFacade.Get(
                id, 
                label, 
                ownerId,
                CardRepository.Get()));
}
