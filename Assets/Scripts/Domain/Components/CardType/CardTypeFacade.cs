public sealed class CardTypeFacade : BaseFacade<ICardTypeComponent>, ICardTypeFacade
{
    private CardTypeFacade(ICardTypeComponent item) : base(item) { }
    public CardType CardType => Item.CardType;
    public bool IsCardType(CardType cardType) => Item.IsCardType(cardType);
    public static ICardTypeFacade Get(CardType cardType) => new CardTypeFacade(CardTypeComponent.Get(cardType));
}