public interface IFacade<T> : IComponent<T>
{
    void AddDecorator(IDecorator<T> decorator);
    void RemoveDecorator(IDecorator<T> decorator);
}
