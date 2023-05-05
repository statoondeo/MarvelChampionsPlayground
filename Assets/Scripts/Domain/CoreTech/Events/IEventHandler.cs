using System;

public interface IEventHandler<T>
{
    void Raise(T eventArg);
    void RegisterListener(Action<T> callback);
    void UnregisterListener(Action<T> callback);
}