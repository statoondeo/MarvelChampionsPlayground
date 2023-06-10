using System;

public interface IEvent<T>
{
    T Reference { get; }
    Action<T> AddListener(Action<T> callback);
    void RemoveListener(Action<T> callback);
    void Raise();
    void Register(T reference);
}

