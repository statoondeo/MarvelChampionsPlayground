public sealed class BoostZone : BaseZone, IBoostZone
{
    private BoostZone(
            IGame game,
            IMediator<IZoneComponent> mediator,
            ICoreZoneComponentFacade coreZoneFacade)
        : base(game, mediator, coreZoneFacade) => SetZone(this);
    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo(1);
    }
    public static IBoostZone Get(IGame game, string id, string label, string ownerId)
        => new BoostZone(
            game,
            ZoneComponentMediator.Get(),
            CoreZoneComponentFacade.Get(
                id,
                label,
                ownerId,
                CardRepository.Get()));
}
