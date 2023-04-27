public interface ICardType
{
    CardType CardType { get; }
    bool IsCardType(CardType cardType);
}
