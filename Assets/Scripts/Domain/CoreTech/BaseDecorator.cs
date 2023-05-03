public abstract class BaseDecorator<T> : IDecorator<T>
{
    protected BaseDecorator() { }
    public IFacade<T> Facade { get; protected set; }
    public T Inner { get; protected set; }
    public void Wrap(T wrapped) => Inner = wrapped;
    public void SetFacade(IFacade<T> facade) => Facade = facade;

}