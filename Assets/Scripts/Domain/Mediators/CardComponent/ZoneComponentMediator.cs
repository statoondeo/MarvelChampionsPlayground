public sealed class ZoneComponentMediator : BaseMediator<IZoneComponent>
{
    private ZoneComponentMediator() : base(ZoneComponentEvent.Get) { }
    public static IMediator<IZoneComponent> Get() => new ZoneComponentMediator();
}