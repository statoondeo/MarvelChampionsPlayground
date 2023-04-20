using System;

public interface IMediator
{
    void Raise(Events eventName);
    void Raise(Events eventName, EventModelArg eventArg);
    void Register(Events eventToListen, Action<EventModelArg> callback);
    void UnRegister(Events eventToListen, Action<EventModelArg> callback);
}
