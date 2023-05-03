using System.Collections.Generic;

public sealed class NoPlayerPicker : IPicker<IPlayer>
{
    private NoPlayerPicker() { }
    public IEnumerable<IPlayer> Pick(IEnumerable<IPlayer> items) => items;
    private static IPicker<IPlayer> Picker;
    public static IPicker<IPlayer> Get() => Picker is null ? Picker = new NoPlayerPicker() : Picker;
}
