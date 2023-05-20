public interface IVillainActorComponent : IActorComponent<IVillainActorComponent>
{
    void DealEncounterCard(IActor player, int number);
    void DealBoostCard(int number);
}
