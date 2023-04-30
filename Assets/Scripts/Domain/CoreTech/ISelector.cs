using System.Collections.Generic;

public interface ISelector<T>
{
    IEnumerable<T> Select(IEnumerable<T> items);
}
