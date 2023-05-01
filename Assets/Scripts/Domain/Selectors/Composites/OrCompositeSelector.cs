using System.Collections.Generic;

public sealed class OrCompositeSelector : BaseCompositeSelector
{
    private OrCompositeSelector(IEnumerable<ISelector<ICard>> commands)
        : base(commands) { }
    public override bool Match(ICard card)
    {
        foreach (ISelector<ICard> selector in Selectors)
            if (selector.Match(card)) return true;
        return false;
    }
    public static ISelector<ICard> Get(params ISelector<ICard>[] selectors) => new OrCompositeSelector(selectors);
}
