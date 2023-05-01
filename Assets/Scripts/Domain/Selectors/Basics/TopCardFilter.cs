public sealed class TopCardFilter : ISelector<ICard>
{
    private readonly int NbCards;
    private TopCardFilter(int nbCards) => NbCards = nbCards;
    public bool Match(ICard card) => card.Order < NbCards;
    public static ISelector<ICard> Get(int nbCards) => new TopCardFilter(nbCards);

}