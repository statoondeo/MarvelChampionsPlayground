using System;

public abstract class BaseComponent<T> : IComponent<T>
{
    protected BaseComponent() { }
    public Action<T> OnChanged { get; set; }
}