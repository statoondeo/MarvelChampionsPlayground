public abstract class BaseFacade<T> : IFacade<T> where T : IComponent<T>
{
    public ICard Card { get; protected set; }
    protected T Item;
    protected BaseFacade(T item) => Item = item;
    public ComponentType Type => Item.Type;
    public void AddDecorator(IDecorator<T> decorator)
    {
        Item = (T)decorator.Wrap(Item);
        decorator.SetFacade(this);
        Card.Raise(Item.Type);
    }
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
                Item = (T)current.Inner;
            else
            {
                previous.Wrap(current.Inner);
            }
            current.SetFacade(null);
            Card.Raise(Item.Type);
            break;
        }
    }
    public virtual void SetCard(ICard card)
    {
        Card = card;
        Item.SetCard(card);
    }
}
