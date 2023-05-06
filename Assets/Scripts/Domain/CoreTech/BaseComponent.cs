public abstract class BaseComponent<T> : IComponent<T> where T : IComponent<T>
{
    public ICard Card { get; protected set; }   
    protected BaseComponent() { }
    public ComponentType Type { get; protected set; }
    public void SetCard(ICard card) => Card = card;
}