public sealed class NoZonePicker : BasePicker<IZone>
{
    private NoZonePicker() : base() { }
    public static IPicker<IZone> Get() => new NoZonePicker();
}