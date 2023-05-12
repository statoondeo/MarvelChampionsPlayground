public interface IFacade<T> : IComponent<T> where T : IComponent
{
    void AddDecorator(IDecorator<T> decorator);
    void RemoveDecorator(IDecorator<T> decorator);
}
