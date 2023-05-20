public interface IActorComponentDecorator<T> : IActorComponent<T> where T : IActorComponent
{
    IActorComponentFacade<T> Facade { get; }
    IActorComponent<T> Inner { get; }
    IActorComponentDecorator<T> Wrap(IActorComponent<T> wrapped);
    void SetFacade(IActorComponentFacade<T> facade);
}