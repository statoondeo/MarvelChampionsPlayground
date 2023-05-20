public abstract class BaseActorComponent<T> : BaseComponent, IActorComponent<T>
{
    protected BaseActorComponent() : base() => ActorHolder = StandardActorHolder.Get();

    #region IActorHolder

    protected IActorHolder ActorHolder;
    public IActor Actor => ActorHolder.Actor;
    public virtual void SetActor(IActor actor) => ActorHolder.SetActor(actor);

    #endregion
}
