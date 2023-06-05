public sealed class VillainActorComponentFacade : BaseActorComponentFacade<IVillainActorComponent>, IVillainActorComponentFacade
{
    #region Constructor

    private VillainActorComponentFacade(IVillainActorComponent item)
        : base(item) { }

    #endregion

    #region IVillainActorComponent

    public void DealEncounterCard(IPlayerActor targetPlayer, int number) => Item.DealEncounterCard(targetPlayer, number);
    public void DealBoostCard(int number) => Item.DealBoostCard(number);

    #endregion

    #region Factory

    public static IVillainActorComponentFacade Get()
        => new VillainActorComponentFacade(VillainActorComponent.Get());

    #endregion
}
