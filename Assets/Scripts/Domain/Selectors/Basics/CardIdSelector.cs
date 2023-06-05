public sealed class CardIdSelector : ISelector<ICard>
{
    private readonly string Item;
    private CardIdSelector(string item) => Item = item;
    public bool Match(ICard card) => card.CardId == Item;
    public static ISelector<ICard> Get(string item) => new CardIdSelector(item);
}
