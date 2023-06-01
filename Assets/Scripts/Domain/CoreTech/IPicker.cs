using System.Collections;
using System.Collections.Generic;

public interface IPicker<T>
{
    IEnumerator Pick(IEnumerable<T> items, IPickReceiver<T> receiver);
}
public interface IPickReceiver<T>
{
    void Receive(IEnumerable<T> items);
}