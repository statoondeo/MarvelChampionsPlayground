public interface IZoneComponentDecorator<T> : IZoneComponent<T> where T : IZoneComponent
{
    IZoneComponentFacade<T> Facade { get; }
    IZoneComponent<T> Inner { get; }
    IZoneComponentDecorator<T> Wrap(IZoneComponent<T> wrapped);
    void SetFacade(IZoneComponentFacade<T> facade);
}
