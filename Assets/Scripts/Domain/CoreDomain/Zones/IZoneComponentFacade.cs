public interface IZoneComponentFacade<T> : IZoneComponent<T> where T : IZoneComponent
{
    void AddDecorator(IZoneComponentDecorator<T> decorator);
    void RemoveDecorator(IZoneComponentDecorator<T> decorator);
}
