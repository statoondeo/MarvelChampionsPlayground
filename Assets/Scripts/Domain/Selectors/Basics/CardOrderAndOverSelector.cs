public sealed class CardOrderAndOverSelector : ISelector<ICard>
{
    private readonly int Item;
    private CardOrderAndOverSelector(int item) => Item = item;
    public bool Match(ICard card) => card.Order >= Item;
    public static ISelector<ICard> Get(int item) => new CardOrderAndOverSelector(item);
}
