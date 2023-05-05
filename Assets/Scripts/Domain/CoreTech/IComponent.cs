public interface IComponent<T>
{
    ComponentType Type { get; }
    void SetCard(ICard card);
}
