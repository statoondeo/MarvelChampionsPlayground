public sealed class FacadeComponent<T> : IFacade<T>
{
    public T Item { get; private set; }
    private FacadeComponent(T item) => Item = item;
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
            {
                Item = current.Inner;
                break;
            }
            previous.Wrap(current.Inner);
            break;
        }
    }
    public static IFacade<T> Get(T item) => new FacadeComponent<T>(item);
}
