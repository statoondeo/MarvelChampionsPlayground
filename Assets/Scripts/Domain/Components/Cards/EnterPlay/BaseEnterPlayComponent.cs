public abstract class BaseEnterPlayComponent : BaseCardComponent<IEnterPlayComponent>, IEnterPlayComponent
{
    protected BaseEnterPlayComponent() : base() { }
    public virtual void EnterPlay() { }
}
