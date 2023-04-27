using System.Collections.Generic;

public abstract class BaseCompositeSelector : ISelector<ICard>
{
    protected IEnumerable<ISelector<ICard>> Selectors;
    protected BaseCompositeSelector(IEnumerable<ISelector<ICard>> commands)
        => Selectors = commands;
    public abstract IEnumerable<ICard> Select(IEnumerable<ICard> cards);
}
