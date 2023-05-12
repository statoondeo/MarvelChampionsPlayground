using System;

public abstract class BaseBehaviourEvent<T> : BaseEvent<T>
{
    protected BaseBehaviourEvent() : base() { }
    public override Action<T> AddListener(Action<T> callback)
    {
        Action<T> listener = base.AddListener(callback);
        listener?.Invoke(Reference);
        return listener;
    }
}
