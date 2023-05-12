public abstract class BaseResetComponent : BaseComponent<IResetComponent>, IResetComponent
{
    public virtual void Reset() => Card.Raise<IResetComponent>();
    protected BaseResetComponent() : base() => Type = ComponentType.Reset;
}
