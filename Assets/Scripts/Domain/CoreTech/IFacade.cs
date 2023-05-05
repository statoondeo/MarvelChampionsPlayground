public interface IFacade<T> : IComponent<T> where T : IComponent<T>
{
    void AddDecorator(IDecorator<T> decorator);
    void RemoveDecorator(IDecorator<T> decorator);
}
