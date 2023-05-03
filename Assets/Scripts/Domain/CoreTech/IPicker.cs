using System.Collections.Generic;

public interface IPicker<T>
{
    IEnumerable<T> Pick(IEnumerable<T> items);
}
