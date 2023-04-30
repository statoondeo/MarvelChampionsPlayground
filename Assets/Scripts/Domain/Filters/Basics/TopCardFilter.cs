using System.Collections.Generic;

public sealed class TopCardFilter : ISelector<ICard>
{
    private readonly int NbCards;
    private TopCardFilter(int nbCards) => NbCards = nbCards;
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        foreach (ICard card in cards) if (card.Order < NbCards) yield return card;
    }
    public static ISelector<ICard> Get(int nbCards) => new TopCardFilter(nbCards);

}