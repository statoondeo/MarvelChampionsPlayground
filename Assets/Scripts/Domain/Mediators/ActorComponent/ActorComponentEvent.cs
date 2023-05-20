public sealed class ActorComponentEvent : BaseEvent<IActorComponent>
{
    private ActorComponentEvent() : base() { }
    public static IEvent<IActorComponent> Get() => new ActorComponentEvent();
}