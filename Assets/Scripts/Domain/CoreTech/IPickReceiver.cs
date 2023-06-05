using System.Collections.Generic;

public interface IPickReceiver<T>
{
    void Receive(IEnumerable<T> items);
}