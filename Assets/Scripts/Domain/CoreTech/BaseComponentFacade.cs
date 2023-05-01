using System;

public abstract class BaseComponentFacade<T> : IFacade<T> where T : IComponent<T>
{
    protected T Item;
    protected BaseComponentFacade(T item) => Item = item;
    public void AddDecorator(IDecorator<T> decorator) => Item = decorator.Wrap(Item);
    public void RemoveDecorator(IDecorator<T> decorator)
    {
        IDecorator<T> previous = null;
        IDecorator<T> current = Item as IDecorator<T>;
        while (current is not null)
        {
            if (current != decorator)
            {
                previous = current;
                current = current.Inner as IDecorator<T>;
                continue;
            }
            if (previous is null)
                Item = current.Inner;
            else
                previous.Wrap(current.Inner);
            Item.Notify(Item);
            break;
        }
    }
    public void Register(Action<T> callback) => Item.Register(callback);
    public void UnRegister(Action<T> callback) => Item.Register(callback);
    public void Notify(T data) => Item.Notify(data);
}
