using System.Collections.Generic;

public sealed class NoActorPicker : IPicker<IActor>
{
    private NoActorPicker() { }
    public IEnumerable<IActor> Pick(IEnumerable<IActor> items) => items;
    public static IPicker<IActor> Get() => new NoActorPicker();
}
