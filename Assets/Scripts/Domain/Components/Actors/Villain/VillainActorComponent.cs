public sealed class VillainActorComponent : BaseActorComponent<IVillainActorComponent>, IVillainActorComponent
{
    private VillainActorComponent() : base() => ActorHolder = StandardActorHolder.Get();
    public void DealEncounterCard(IPlayerActor targetPlayer, int number)
    {
        ICard card = Actor.Game.GetLast(
            AndCompositeSelector.Get(
                OwnerIdSelector.Get(Actor.Id),
                LocationSelector.Get("DECK")));
        IZone zone = Actor.Game.GetFirst(ZoneNameSelector.Get(Actor.Game, targetPlayer.Id, "ENCOUNTER"));
        card.MoveTo(zone.Id);
    }

    public void DealBoostCard(int number) { }

    public static IVillainActorComponent Get() => new VillainActorComponent();
}
