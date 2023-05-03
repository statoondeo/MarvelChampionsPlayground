using System.Collections.Generic;

public sealed class NoCardPicker : IPicker<ICard>
{
    private NoCardPicker() { }
    public IEnumerable<ICard> Pick(IEnumerable<ICard> items) => items;
    private static IPicker<ICard> Picker;
    public static IPicker<ICard> Get() => Picker is null ? Picker = new NoCardPicker() : Picker;
}
