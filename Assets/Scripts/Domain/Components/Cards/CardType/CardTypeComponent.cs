﻿public sealed class CardTypeComponent : BaseCardComponent<ICardTypeComponent>, ICardTypeComponent
{
    public CardType CardType { get; private set; }
    private CardTypeComponent(CardType cardType) : base() => CardType = cardType;
    public bool IsCardType(CardType cardType) => CardType.Equals(cardType);
    public static ICardTypeComponent Get(CardType cardType) => new CardTypeComponent(cardType);
}
