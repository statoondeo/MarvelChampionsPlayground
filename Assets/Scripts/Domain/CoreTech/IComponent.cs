public interface IComponent<T> : ICardHolder
{
    ComponentType Type { get; }
}
