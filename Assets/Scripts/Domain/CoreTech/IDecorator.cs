public interface IDecorator<T> : IComponent<T> where T : IComponent
{
    IFacade<T> Facade { get; }
    IComponent<T> Inner { get; }
    IDecorator<T> Wrap(IComponent<T> wrapped);
    void SetFacade(IFacade<T> facade);
}
