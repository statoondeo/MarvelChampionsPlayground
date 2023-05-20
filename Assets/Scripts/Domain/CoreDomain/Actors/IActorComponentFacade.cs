public interface IActorComponentFacade<T> : IActorComponent<T> where T : IActorComponent
{
    void AddDecorator(IActorComponentDecorator<T> decorator);
    void RemoveDecorator(IActorComponentDecorator<T> decorator);
}
