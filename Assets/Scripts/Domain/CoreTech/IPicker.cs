using System.Collections;
using System.Collections.Generic;

public interface IPicker<T>
{
    IEnumerator Pick(IEnumerable<T> items, IPickReceiver<T> receiver, string title, string subTitle);
}
