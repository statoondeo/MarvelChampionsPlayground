public sealed class VillainActorComponent : BaseActorComponent<IVillainActorComponent>, IVillainActorComponent
{
    private VillainActorComponent() : base() => ActorHolder = StandardActorHolder.Get();
    public void DealEncounterCard(IActor Villain, int number) { }
    public void DealBoostCard(int number) { }

    public static IVillainActorComponent Get() => new VillainActorComponent();
}
