using System.Collections.Generic;

public sealed class NoFilterSelector : ISelector<ICard>
{
    private NoFilterSelector() { }
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards) => cards;
    public static ISelector<ICard> Get() => new NoFilterSelector();
}
