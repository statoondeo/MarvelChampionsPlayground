public abstract class BaseActorComponentDecorator<T> : IActorComponentDecorator<T> where T : IActorComponent
{
    protected BaseActorComponentDecorator() { }

    #region IActorComponentDecorator

    public IActorComponentFacade<T> Facade { get; protected set; }
    public IActorComponent<T> Inner { get; protected set; }

    public IActorComponentDecorator<T> Wrap(IActorComponent<T> wrapped)
    {
        Inner = wrapped;
        return this;
    }
    public void SetFacade(IActorComponentFacade<T> facade) => Facade = facade;

    #endregion

    #region IActorComponent

    public void Init() => Inner.Init();

    #endregion

    #region IActorHolder

    public IActor Actor => Inner.Actor;
    public void SetActor(IActor actor) => Inner.SetActor(actor);

    #endregion
}