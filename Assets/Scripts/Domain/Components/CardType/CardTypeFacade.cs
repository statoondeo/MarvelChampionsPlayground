using System;

public sealed class CardTypeFacade : ICardTypeFacade
{
    private readonly IFacade<ICardTypeComponent> Facade;
    private CardTypeFacade(ICardTypeComponent item) => Facade = FacadeComponent<ICardTypeComponent>.Get(item);

    #region IFacade<ICardType>

    public ICardTypeComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ICardTypeComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICardTypeComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ICardType

    public Action<ICardTypeComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public CardType CardType => Item.CardType;
    public bool IsCardType(CardType cardType) => Item.IsCardType(cardType);

    #endregion

    public static ICardTypeFacade Get(CardType cardType) => new CardTypeFacade(CardTypeComponent.Get(cardType));
}