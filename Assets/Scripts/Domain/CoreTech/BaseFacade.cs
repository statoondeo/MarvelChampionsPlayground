public abstract class BaseFacade<T> : IFacade<T> where T : class, IComponent<T>
{
    protected T Item;
    protected BaseFacade(T item) => Item = item;
    public void AddDecorator(IDecorator<T> decorator)
    {
        Item = (T)decorator.Wrap(Item);
        decorator.SetFacade(this);
        Card.Raise<T>();
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
            Card.Raise<T>();
            break;
        }
    }

    public void Init() => Item.Init();

    #region ICardHolder

    public ICard Card { get; protected set; }
    public virtual void SetCard(ICard card)
    {
        Card = card;
        Item.SetCard(card);
    }

    #endregion
}
