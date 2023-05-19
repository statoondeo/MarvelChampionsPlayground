public sealed class ZoneComponentEvent : BaseEvent<IZoneComponent>
{
    private ZoneComponentEvent() : base() { }
    public static IEvent<IZoneComponent> Get() => new ZoneComponentEvent();
}