public abstract class BaseCardComponentFacade<T> : ICardComponentFacade<T> where T : class, ICardComponent<T>
{
    protected BaseCardComponentFacade(T item) => Item = item;

    #region ICardComponentFacade

    protected T Item;
    public void AddDecorator(ICardComponentDecorator<T> decorator)
    {
        Item = (T)decorator.Wrap(Item);
        decorator.SetFacade(this);
        Card.Raise<T>();
    }
    public void RemoveDecorator(ICardComponentDecorator<T> decorator)
    {
        ICardComponentDecorator<T> previous = null;
        ICardComponentDecorator<T> current = Item as ICardComponentDecorator<T>;
        while (current is not null)
        {
            if (current != decorator)
            {
                previous = current;
                current = current.Inner as ICardComponentDecorator<T>;
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

    #endregion

    #region ICardComponent

    public void Init() => Item.Init();

    #endregion

    #region ICardHolder

    public ICard Card => Item.Card;
    public virtual void SetCard(ICard card) => Item.SetCard(card);

    #endregion
}
