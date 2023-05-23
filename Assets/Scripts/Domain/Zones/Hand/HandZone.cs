public sealed class HandZone : BaseZone, IHandZone
{
    private HandZone(
            IGame game,
            IMediator<IZoneComponent> mediator,
            ICoreZoneComponentFacade coreZoneFacade)
        : base(game, mediator, coreZoneFacade) => SetZone(this);
    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo(0);
    }
    public static IHandZone Get(IGame game, string id, string label, string ownerId)
        => new HandZone(
            game,
            ZoneComponentMediator.Get(),
            CoreZoneComponentFacade.Get(
                id,
                label,
                ownerId,
                CardRepository.Get()));
}
