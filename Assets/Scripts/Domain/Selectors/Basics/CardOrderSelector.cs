public sealed class CardOrderSelector : ISelector<ICard>
{
    private readonly int Item;
    private CardOrderSelector(int item) => Item = item;
    public bool Match(ICard card) => card.Order == Item;
    public static ISelector<ICard> Get(int item) => new CardOrderSelector(item);
}
