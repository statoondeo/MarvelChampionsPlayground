using System.Collections.Generic;
using System.Linq;

public sealed class OrCompositeSelector : BaseCompositeSelector
{
    private OrCompositeSelector(IEnumerable<ISelector<ICard>> commands)
        : base(commands) { }
    public override IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        IEnumerable<ICard> result = Enumerable.Empty<ICard>();
        foreach (ISelector<ICard> command in Selectors)
            result = result.Union(command.Select(result));
        return result;
    }
    public static ISelector<ICard> Get(params ISelector<ICard>[] selectors) => new OrCompositeSelector(selectors);
}
