using System.Collections.Generic;
using System;

public abstract class BaseMediator<T, U> : IMediator<T, U>
{
    protected readonly IDictionary<T, IEventHandler<U>> EventsAtlas;
    protected readonly Func<IEventHandler<U>> EventFactory;

    protected BaseMediator(Func<IEventHandler<U>> eventFactory)
    {
        EventsAtlas = new Dictionary<T, IEventHandler<U>>();
        EventFactory = eventFactory;
    }
    protected IEventHandler<U> GetEvent(T eventName)
    {
        if (!EventsAtlas.ContainsKey(eventName)) EventsAtlas.Add(eventName, EventFactory.Invoke());
        return EventsAtlas[eventName];
    }
    public virtual void Raise(T eventName) => Raise(eventName, default);
    public void Raise(T eventName, U eventArg) => GetEvent(eventName).Raise(eventArg);
    public void Register(T eventToListen, Action<U> callback) => GetEvent(eventToListen).RegisterListener(callback);
    public void UnRegister(T eventToListen, Action<U> callback) => GetEvent(eventToListen).UnregisterListener(callback);
}
