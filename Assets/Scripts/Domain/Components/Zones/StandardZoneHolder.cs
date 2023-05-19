public sealed class StandardZoneHolder : IZoneHolder
{
    private StandardZoneHolder() { }
    public IZone Zone { get; private set; }
    public void SetZone(IZone zone) => Zone = zone;
    public static IZoneHolder Get() => new StandardZoneHolder();
}