public interface ICardType
{
    CardType CardType { get; }
    bool IsCardType(CardType cardType);
    bool IsOneOfCardType(CardType cardType1, CardType cardType2);
    bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3);
    bool IsOneOfCardType(CardType cardType1, CardType cardType2, CardType cardType3, CardType cardType4);
}
