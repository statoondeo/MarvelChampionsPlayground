using System;

public abstract class BaseComponent<T> : IComponent<T>
{
    protected BaseComponent() { }
    protected Action<T> OnChanged;
    public void Register(Action<T> callback) => OnChanged += callback;
    public void UnRegister(Action<T> callback) => OnChanged -= callback;
    public void Notify(T data) => OnChanged?.Invoke(data);
}