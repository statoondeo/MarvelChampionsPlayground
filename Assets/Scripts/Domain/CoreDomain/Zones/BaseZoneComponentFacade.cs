public abstract class BaseZoneComponentFacade<T> : IZoneComponentFacade<T> where T : class, IZoneComponent<T>
{
    protected BaseZoneComponentFacade(T item) => Item = item;

    #region IZoneComponentFacade

    protected T Item;
    public void AddDecorator(IZoneComponentDecorator<T> decorator)
    {
        Item = (T)decorator.Wrap(Item);
        decorator.SetFacade(this);
        Zone.Raise<T>();
    }
    public void RemoveDecorator(IZoneComponentDecorator<T> decorator)
    {
        IZoneComponentDecorator<T> previous = null;
        IZoneComponentDecorator<T> current = Item as IZoneComponentDecorator<T>;
        while (current is not null)
        {
            if (current != decorator)
            {
                previous = current;
                current = current.Inner as IZoneComponentDecorator<T>;
                continue;
            }
            if (previous is null)
                Item = (T)current.Inner;
            else
            {
                previous.Wrap(current.Inner);
            }
            current.SetFacade(null);
            Zone.Raise<T>();
            break;
        }
    }

    #endregion

    #region IZoneComponent

    public void Init() => Item.Init();

    #endregion

    #region IZoneHolder

    public IZone Zone => Item.Zone;
    public void SetZone(IZone zone) => Item.SetZone(zone);

    #endregion
}
