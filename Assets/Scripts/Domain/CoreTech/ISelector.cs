public interface ISelector<T>
{
    bool Match(T item);
}
