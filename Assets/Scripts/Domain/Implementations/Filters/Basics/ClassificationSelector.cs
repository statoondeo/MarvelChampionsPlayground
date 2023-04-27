using System.Collections.Generic;

public sealed class ClassificationSelector : ISelector<ICard>
{
    private readonly Classification Item;
    private ClassificationSelector(Classification item) => Item = item;
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        foreach (ICard card in cards)
            if (card.IsClassification(Item)) yield return card;
    }
    public static ISelector<ICard> Get(Classification item) => new ClassificationSelector(item);
}
