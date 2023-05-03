using System.Collections.Generic;

public interface IRepository<T>
{
    void Add(T item);
    void Remove(T item);
    int Count(ISelector<T> selector);
    bool Contains(T item);
    T GetFirst(ISelector<T> selector);
    IEnumerable<T> GetAll(ISelector<T> selector);
}
