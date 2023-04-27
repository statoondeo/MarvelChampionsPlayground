public interface IDecorator<T>
{
    T Inner { get; }
    T Wrap(T wrapped);
}
