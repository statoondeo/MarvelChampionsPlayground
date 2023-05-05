using System;

public interface IMediator<T, U>
{
    void Raise(T eventName);
    void Raise(T eventName, U eventArg);
    void Register(T eventToListen, Action<U> callback);
    void UnRegister(T eventToListen, Action<U> callback);
}
