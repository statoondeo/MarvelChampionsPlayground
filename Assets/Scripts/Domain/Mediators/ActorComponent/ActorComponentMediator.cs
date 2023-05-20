public sealed class ActorComponentMediator : BaseMediator<IActorComponent>
{
    private ActorComponentMediator() : base(ActorComponentEvent.Get) { }
    public static IMediator<IActorComponent> Get() => new ActorComponentMediator();
}