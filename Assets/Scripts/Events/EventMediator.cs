using System.Collections.Generic;
using System;

public class EventMediator : IMediator
{
    private readonly Dictionary<Events, EventModel> EventsAtlas = new Dictionary<Events, EventModel>();
    private EventModel GetEvent(Events eventName)
    {
        if (!EventsAtlas.ContainsKey(eventName)) EventsAtlas.Add(eventName, new EventModel());
        return EventsAtlas[eventName];
    }

    public void Raise(Events eventName) => Raise(eventName, EventModelArg.Empty);
    public void Raise(Events eventName, EventModelArg eventArg) => GetEvent(eventName).Raise(eventArg);
    public void Register(Events eventToListen, Action<EventModelArg> callback) => GetEvent(eventToListen).RegisterListener(callback);
    public void UnRegister(Events eventToListen, Action<EventModelArg> callback) => GetEvent(eventToListen).UnregisterListener(callback);
}
