using System;
using System.Linq;

public abstract class BaseEvent<T> : IEvent<T>
{
    public T Reference { get; protected set; }
    protected Action<T> Listeners;
    protected BaseEvent() { }
    public virtual Action<T> AddListener(Action<T> callback)
    {
        if ((Listeners is not null) && Listeners.GetInvocationList().Contains(callback))
            return default;
        Listeners += callback;
        return callback;
    }
    public void RemoveListener(Action<T> callback)
    {
        if ((Listeners is not null) && Listeners.GetInvocationList().Contains(callback))
            Listeners -= callback;
    }
    public void Raise() => Listeners?.Invoke(Reference);
    public void Register(T reference) => Reference = reference;
}
