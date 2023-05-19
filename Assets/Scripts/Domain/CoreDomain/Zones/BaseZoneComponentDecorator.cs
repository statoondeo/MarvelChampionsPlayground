public abstract class BaseZoneComponentDecorator<T> : IZoneComponentDecorator<T> where T : IZoneComponent
{
    protected BaseZoneComponentDecorator() { }

    #region IZoneComponentDecorator

    public IZoneComponentFacade<T> Facade { get; protected set; }
    public IZoneComponent<T> Inner { get; protected set; }

    public IZoneComponentDecorator<T> Wrap(IZoneComponent<T> wrapped)
    {
        Inner = wrapped;
        return this;
    }
    public void SetFacade(IZoneComponentFacade<T> facade) => Facade = facade;

    #endregion

    #region IZoneComponent

    public void Init() => Inner.Init();

    #endregion

    #region IZoneHolder

    public IZone Zone => Inner.Zone;
    public void SetZone(IZone zone) => Inner.SetZone(zone);

    #endregion
}