using System.Collections.Generic;
using System.Linq;

public sealed class AndCompositeSelector : BaseCompositeSelector
{
    private AndCompositeSelector(IEnumerable<ISelector<ICard>> commands)
        : base(commands) { }
    public override IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        IEnumerable<ICard> result = cards;
        foreach (ISelector<ICard> command in Selectors)
            result = result.Intersect(command.Select(result));
        return result;
    }
    public static ISelector<ICard> Get(params ISelector<ICard>[] selectors) => new AndCompositeSelector(selectors);
}
