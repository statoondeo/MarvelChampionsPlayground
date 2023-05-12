public abstract class BaseComponent<T> : IComponent<T> where T : IComponent
{
    public ICard Card { get; protected set; }   
    protected BaseComponent() { }
    public ComponentType Type { get; protected set; }
    public virtual void SetCard(ICard card) => Card = card;
}