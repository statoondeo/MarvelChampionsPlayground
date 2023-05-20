public abstract class BaseVillainActorComponentDecorator : BaseActorComponentDecorator<IVillainActorComponent>, IVillainActorComponent
{
    #region ICoreActorComponent

    private IVillainActorComponent InnerComponent => Inner as IVillainActorComponent;
    public void DealEncounterCard(IActor Villain, int number) => InnerComponent.DealEncounterCard(Villain, number);
    public void DealBoostCard(int number) => InnerComponent.DealBoostCard(number);

    #endregion
}