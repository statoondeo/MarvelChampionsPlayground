using System.Collections.Generic;

public sealed class AndCompositeSelector : BaseCompositeSelector
{
    private AndCompositeSelector(IEnumerable<ISelector<ICard>> selectors)
        : base(selectors) { }
    public override bool Match(ICard card)
    {
        foreach (ISelector<ICard> selector in Selectors)
            if (!selector.Match(card)) return false;
        return true;
    }
    public static ISelector<ICard> Get(params ISelector<ICard>[] selectors) 
        => new AndCompositeSelector(selectors);
}
