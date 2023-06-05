public interface IVillainActorComponent : IActorComponent<IVillainActorComponent>
{
    void DealEncounterCard(IPlayerActor targetPlayer, int number);
    void DealBoostCard(int number);
}
