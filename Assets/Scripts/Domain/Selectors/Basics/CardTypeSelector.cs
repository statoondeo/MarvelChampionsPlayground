public sealed class CardTypeSelector : ISelector<ICard>
{
    private readonly CardType Item;
    private CardTypeSelector(CardType item) => Item = item;
    public bool Match(ICard card) => card.IsCardType(Item);
    public static ISelector<ICard> Get(CardType item) => new CardTypeSelector(item);
}
