public abstract class BaseEnterPlayComponent : BaseComponent<IEnterPlayComponent>, IEnterPlayComponent
{
    protected BaseEnterPlayComponent() : base() { }
    public virtual void EnterPlay() { }
}
