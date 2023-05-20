using System.Collections.Generic;

public sealed class PlayerActor : BaseActor, IPlayerActor
{
    private PlayerActor(
            IGame game,
            IMediator<IActorComponent> mediator,
            ICoreActorComponentFacade coreActorComponentFacade,
            IPlayerActorComponentFacade playerActorComponentFacade)
        : base(
            game,
            mediator,
            coreActorComponentFacade)
    {
        PlayerActorItem = playerActorComponentFacade;
        Mediator.Register<IPlayerActorComponent>(PlayerActorItem);
        SetActor(this);
    }

    #region IActorHolder

    public override void SetActor(IActor actor)
    {
        base.SetActor(actor);
        PlayerActorItem.SetActor(actor);
    }

    #endregion

    #region IPlayerActor

    private readonly IPlayerActorComponentFacade PlayerActorItem;
    public void Draw(int number) => PlayerActorItem.Draw(number);
    public IEnumerable<ICard> EncounterCards => PlayerActorItem.EncounterCards;
    public void AddDecorator(IActorComponentDecorator<IPlayerActorComponent> decorator)
        => PlayerActorItem.AddDecorator(decorator);
    public void RemoveDecorator(IActorComponentDecorator<IPlayerActorComponent> decorator) 
        => PlayerActorItem.RemoveDecorator(decorator);

    #endregion

    public static IActor Get(
            IGame game,
            string id, 
            string title, 
            HeroType heroType)
    {
        return new PlayerActor(
            game,
            ActorComponentMediator.Get(),
            CoreActorComponentFacade.Get(id, title, heroType),
            PlayerActorComponentFacade.Get());
    }
}
