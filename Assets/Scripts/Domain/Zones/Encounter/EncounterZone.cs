public sealed class EncounterZone : BaseZone, IEncounterZone
{
    private EncounterZone(
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
    public static IEncounterZone Get(IGame game, string id, string label, string ownerId)
        => new EncounterZone(
            game,
            ZoneComponentMediator.Get(),
            CoreZoneComponentFacade.Get(
                id,
                label,
                ownerId,
                CardRepository.Get()));
}
