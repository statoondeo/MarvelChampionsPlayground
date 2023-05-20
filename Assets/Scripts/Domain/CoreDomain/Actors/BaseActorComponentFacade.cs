public abstract class BaseActorComponentFacade<T> : IActorComponentFacade<T> where T : class, IActorComponent<T>
{
    protected BaseActorComponentFacade(T item) => Item = item;

    #region IActorComponentFacade

    protected T Item;
    public void AddDecorator(IActorComponentDecorator<T> decorator)
    {
        Item = (T)decorator.Wrap(Item);
        decorator.SetFacade(this);
        Actor.Raise<T>();
    }
    public void RemoveDecorator(IActorComponentDecorator<T> decorator)
    {
        IActorComponentDecorator<T> previous = null;
        IActorComponentDecorator<T> current = Item as IActorComponentDecorator<T>;
        while (current is not null)
        {
            if (current != decorator)
            {
                previous = current;
                current = current.Inner as IActorComponentDecorator<T>;
                continue;
            }
            if (previous is null)
                Item = (T)current.Inner;
            else
            {
                previous.Wrap(current.Inner);
            }
            current.SetFacade(null);
            Actor.Raise<T>();
            break;
        }
    }

    #endregion

    #region IActorComponent

    public void Init() => Item.Init();

    #endregion

    #region IActorHolder

    public IActor Actor => Item.Actor;
    public void SetActor(IActor actor) => Item.SetActor(actor);

    #endregion
}
