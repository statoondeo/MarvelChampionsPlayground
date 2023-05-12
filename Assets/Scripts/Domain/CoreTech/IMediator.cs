using System;

public interface IMediator<T>
{
    void AddListener<U>(Action<T> callback) where U : T;
    void Raise<U>() where U : class, T;
    public IEvent<T> GetEventHandler<U>() where U : T;
    public void Register<U>(IEvent<T> eventHandler) where U : T;
    void Register<U>(U reference) where U : T;
    void RemoveListener<U>(Action<T> callback) where U : T;
    void UnRegister<U>(U reference) where U : T;
    U GetFacade<U>() where U : T;
}
