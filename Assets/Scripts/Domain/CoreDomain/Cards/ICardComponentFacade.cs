public interface ICardComponentFacade<T> : ICardComponent<T> where T : ICardComponent
{
    void AddDecorator(ICardComponentDecorator<T> decorator);
    void RemoveDecorator(ICardComponentDecorator<T> decorator);
}
