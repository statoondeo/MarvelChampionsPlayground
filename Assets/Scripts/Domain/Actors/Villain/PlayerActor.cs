public sealed class VillainActor : BaseActor, IVillainActor
{
    private VillainActor(
            IGame game,
            IMediator<IActorComponent> mediator,
            ICoreActorComponentFacade coreActorComponentFacade,
            IVillainActorComponentFacade villainActorComponentFacade)
        : base(
            game,
            mediator,
            coreActorComponentFacade)
    {
        VillainActorItem = villainActorComponentFacade;
        Mediator.Register<IVillainActorComponent>(VillainActorItem);
        SetActor(this);
    }

    #region IActorHolder

    public override void SetActor(IActor actor)
    {
        base.SetActor(actor);
        VillainActorItem.SetActor(actor);
    }

    #endregion

    #region IVillainActor

    private readonly IVillainActorComponentFacade VillainActorItem;
    public void DealEncounterCard(IPlayerActor targetPlayer, int number) => VillainActorItem.DealEncounterCard(targetPlayer, number);
    public void DealBoostCard(int number) => VillainActorItem.DealBoostCard(number);

    public void AddDecorator(IActorComponentDecorator<IVillainActorComponent> decorator)
        => VillainActorItem.AddDecorator(decorator);
    public void RemoveDecorator(IActorComponentDecorator<IVillainActorComponent> decorator) 
        => VillainActorItem.RemoveDecorator(decorator);

    #endregion

    public static IActor Get(
            IGame game,
            string id, 
            string title, 
            HeroType heroType)
    {
        return new VillainActor(
            game,
            ActorComponentMediator.Get(),
            CoreActorComponentFacade.Get(id, title, heroType),
            VillainActorComponentFacade.Get());
    }
}
