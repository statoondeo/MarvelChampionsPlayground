using System;
using System.Collections.Generic;

public abstract class BaseMediator<T> : IMediator<T>
{
    protected BaseMediator(Func<IEvent<T>> eventModelFactory)
    {
        EventsAtlas = new Dictionary<Type, IEvent<T>>();
        EventModelFactory = eventModelFactory;
    }
    protected readonly Dictionary<Type, IEvent<T>> EventsAtlas;
    protected readonly Func<IEvent<T>> EventModelFactory;
    public void Raise<U>() where U : class, T => EventsAtlas[typeof(U)].Raise();
    public void AddListener<U>(Action<T> callback) where U : T => EventsAtlas[typeof(U)].AddListener(callback);
    public void RemoveListener<U>(Action<T> callback) where U : T => EventsAtlas[typeof(U)].RemoveListener(callback);
    public U GetFacade<U>() where U : T
    {
        if (EventsAtlas.TryGetValue(typeof(U), out IEvent<T> eventHandler)) return (U)eventHandler.Reference;
        return default;
    }
    public void Register<U>(U reference) where U : T
    {
        if (EventsAtlas.ContainsKey(typeof(U))) return;
        EventsAtlas.Add(typeof(U), EventModelFactory.Invoke());
        EventsAtlas[typeof(U)].Register(reference);
    }
    public IEvent<T> GetEventHandler<U>() where U : T => EventsAtlas[typeof(U)];
    public void Register<U>(IEvent<T> eventHandler) where U : T
    {
        if (EventsAtlas.ContainsKey(typeof(U))) return;
        EventsAtlas.Add(typeof(U), eventHandler);
    }
    public void UnRegister<U>(U reference) where U : T
    {
        if (!EventsAtlas.ContainsKey(typeof(U))) return;
        EventsAtlas.Remove(typeof(U));
    }
}
