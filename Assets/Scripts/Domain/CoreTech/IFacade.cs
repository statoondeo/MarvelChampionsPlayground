public interface IFacade<T>
{
    T Item { get; }
    void AddDecorator(IDecorator<T> decorator);
    void RemoveDecorator(IDecorator<T> decorator);
}
