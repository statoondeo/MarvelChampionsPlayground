public interface IDecorator<T>
{
    IFacade<T> Facade { get; }
    T Inner { get; }
    void Wrap(T wrapped);
    void SetFacade(IFacade<T> facade);
}
