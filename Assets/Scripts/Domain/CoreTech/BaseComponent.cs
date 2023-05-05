public abstract class BaseComponent<T> : IComponent<T> where T : IComponent<T>
{
    protected ICard Card;
    protected BaseComponent() { }
    public ComponentType Type { get; protected set; }
    public void SetCard(ICard card) => Card = card;
}