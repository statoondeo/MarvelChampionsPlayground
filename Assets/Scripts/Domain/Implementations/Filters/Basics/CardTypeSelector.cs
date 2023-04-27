using System.Collections.Generic;

public sealed class CardTypeSelector : ISelector<ICard>
{
    private readonly CardType Item;
    private CardTypeSelector(CardType item) => Item = item;
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        foreach (ICard card in cards)
            if (card.IsCardType(Item)) yield return card;
    }
    public static ISelector<ICard> Get(CardType item) => new CardTypeSelector(item);
}
