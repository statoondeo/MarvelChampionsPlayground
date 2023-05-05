public abstract class BaseDecorator<T> : IDecorator<T> where T : IComponent<T>
{
    protected ICard Card;
    protected BaseDecorator() { }
    public ComponentType Type => Inner.Type;
    public IFacade<T> Facade { get; protected set; }
    public IComponent<T> Inner { get; protected set; }
    public IDecorator<T> Wrap(IComponent<T> wrapped)
    {
        Inner = wrapped;
        return this;
    }
    public void SetFacade(IFacade<T> facade) => Facade = facade;
    public void SetCard(ICard card)
    {
        Card = card;
        Inner.SetCard(card);
    }
}