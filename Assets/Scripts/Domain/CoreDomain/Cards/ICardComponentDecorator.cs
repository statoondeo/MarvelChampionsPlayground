public interface ICardComponentDecorator<T> : ICardComponent<T> where T : ICardComponent
{
    ICardComponentFacade<T> Facade { get; }
    ICardComponent<T> Inner { get; }
    ICardComponentDecorator<T> Wrap(ICardComponent<T> wrapped);
    void SetFacade(ICardComponentFacade<T> facade);
}
