using System;
using System.Collections.Generic;

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
public enum SelectionEvent
{
    OnSelectionStarted,
    OnSelectionEnded,
    OnItemSelected,
    OnItemUnSelected,
}
public interface ISelectionEvent
{
    void AddListener(Action<ISelectionEventParam> callback);
    void RemoveListener(Action<ISelectionEventParam> callback);
    void Raise(ISelectionEventParam selectionEventParam);
}
public interface ISelectionEventParam { }
public sealed class OnSelectionStartedEventParam : ISelectionEventParam
{
    public ISelector<ICard> Selector { get; private set; }
    public bool IsSelected { get; private set; }
    private OnSelectionStartedEventParam(ISelector<ICard> selector, bool isSelected)
    {
        Selector = selector;
        IsSelected = isSelected;
    }
    public static ISelectionEventParam Get(ISelector<ICard> selector, bool isSelected = false) 
        => new OnSelectionStartedEventParam(selector, isSelected);
}
public sealed class OnItemSelectionEventParam : ISelectionEventParam
{
    public ICard Item { get; private set; }
    private OnItemSelectionEventParam(ICard item) => Item = item;
    public static ISelectionEventParam Get(ICard item) => new OnItemSelectionEventParam(item);
}
public sealed class OnSelectionEndedEventParam : ISelectionEventParam
{
    private OnSelectionEndedEventParam() { }
    public static ISelectionEventParam Get() => new OnSelectionEndedEventParam();
}
public interface ISelectionMediator
{
    void Raise(SelectionEvent selectionEvent, ISelectionEventParam selectionEventParam);
    void AddListener(SelectionEvent selectionEvent, Action<ISelectionEventParam> callback);
    void RemoveListener(SelectionEvent selectionEvent, Action<ISelectionEventParam> callback);
}
public sealed class StandardSelectionMediator : ISelectionMediator
{
    private readonly IDictionary<SelectionEvent, ISelectionEvent> EventHandlers;
    private readonly Func<ISelectionEvent> EventHandlerFactory;
    private StandardSelectionMediator(Func<ISelectionEvent> eventHandlerFactory)
    {
        EventHandlers = new Dictionary<SelectionEvent, ISelectionEvent>();
        EventHandlerFactory = eventHandlerFactory;
    }
    private ISelectionEvent GetHandler(SelectionEvent selectionEvent)
    {
        if (EventHandlers.TryGetValue(selectionEvent, out ISelectionEvent selectionEventObject)) return selectionEventObject;
        ISelectionEvent newSelectionEvent = EventHandlerFactory.Invoke();
        EventHandlers.Add(selectionEvent, newSelectionEvent);
        return newSelectionEvent;
    }
    public void Raise(SelectionEvent selectionEvent, ISelectionEventParam selectionEventParam)
        => GetHandler(selectionEvent).Raise(selectionEventParam);
    public void AddListener(SelectionEvent selectionEvent, Action<ISelectionEventParam> callback)
        => GetHandler(selectionEvent).AddListener(callback);
    public void RemoveListener(SelectionEvent selectionEvent, Action<ISelectionEventParam> callback)
        => GetHandler(selectionEvent).RemoveListener(callback);
    public static ISelectionMediator Get() => new StandardSelectionMediator(StandardSelectionEvent.Get);
}
public sealed class StandardSelectionEvent : ISelectionEvent
{
    private Action<ISelectionEventParam> EventHandler;
    private StandardSelectionEvent() { }
    public void AddListener(Action<ISelectionEventParam> callback) => EventHandler += callback;
    public void RemoveListener(Action<ISelectionEventParam> callback) => EventHandler -= callback;
    public void Raise(ISelectionEventParam selectionEventParam) => EventHandler?.Invoke(selectionEventParam);
    public static ISelectionEvent Get() => new StandardSelectionEvent();
}