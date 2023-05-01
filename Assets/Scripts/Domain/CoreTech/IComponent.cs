using System;

public interface IComponent<T>
{
    void Register(Action<T> callback);
    void UnRegister(Action<T> callback);
    void Notify(T data);
}
