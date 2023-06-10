using System.Collections.Generic;

public interface IPickReceiver<T>
{
    IEnumerable<T> SelectedItems { get; }
    void Receive(IEnumerable<T> items);
}