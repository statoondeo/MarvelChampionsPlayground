using System;

public interface IComponent<T>
{
    Action<T> OnChanged { get; set; }
}
