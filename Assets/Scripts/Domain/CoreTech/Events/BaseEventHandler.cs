using System;

public abstract class BaseEventHandler<T> : IEventHandler<T>
{
    protected BaseEventHandler() { }
    protected Action<T> Listeners;
    public void Raise(T eventArg) => Listeners?.Invoke(eventArg);
    public void RegisterListener(Action<T> callback) => Listeners += callback;
    public void UnregisterListener(Action<T> callback) => Listeners -= callback;
}
