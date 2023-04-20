public sealed class CardTypeComponent : ICardType
{
    public CardType CardType { get; private set; }
    public CardTypeComponent(CardType cardType) => CardType = cardType;
    public bool IsCardType(CardType cardType) => CardType == cardType;
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2) 
        => IsCardType(cardType1) || IsCardType(cardType2);
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3) 
        => IsOneOfCardType(cardType1, cardType2) || IsCardType(cardType3);
    public bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3, CardType cardType4) 
        => IsOneOfCardType(cardType1, cardType2) || IsOneOfCardType(cardType3, cardType4);
}
