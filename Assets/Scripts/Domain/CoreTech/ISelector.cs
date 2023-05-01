using System.Collections.Generic;

public interface ISelector<T>
{
    bool Match(T item);
}
