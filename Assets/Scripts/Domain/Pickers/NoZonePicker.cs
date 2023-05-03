using System.Collections.Generic;

public sealed class NoZonePicker : IPicker<IZone>
{
    private NoZonePicker() { }
    public IEnumerable<IZone> Pick(IEnumerable<IZone> items) => items;
    private static IPicker<IZone> Picker;
    public static IPicker<IZone> Get() => Picker is null ? Picker = new NoZonePicker() : Picker;
}