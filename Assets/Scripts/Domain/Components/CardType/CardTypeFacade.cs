public sealed class CardTypeFacade : BaseComponentFacade<ICardTypeComponent>, ICardTypeFacade
{
    private CardTypeFacade(ICardTypeComponent item) : base(item) { }

    #region ICardType

    public CardType CardType => Item.CardType;
    public bool IsCardType(CardType cardType) => Item.IsCardType(cardType);

    #endregion

    public static ICardTypeFacade Get(CardType cardType) => new CardTypeFacade(CardTypeComponent.Get(cardType));
}