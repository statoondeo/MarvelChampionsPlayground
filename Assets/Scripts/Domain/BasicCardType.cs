public sealed class CardTypeComponent : ICardType
{
    public CardType CardType { get; private set; }
    private CardTypeComponent(CardType cardType) => CardType = cardType;
    public bool IsCardType(CardType cardType) => CardType == cardType;
    public static ICardType Get(CardType cardType) => new CardTypeComponent(cardType);
}
public interface ICardTypeFacade : IFacade<ICardType>, ICardType { }
public sealed class CardTypeFacade : ICardTypeFacade
{
    private readonly IFacade<ICardType> Facade;
    private CardTypeFacade(ICardType item) => Facade = FacadeComponent<ICardType>.Get(item);

    #region IFacade<ICardType>

    public ICardType Item { get; private set; }
    public void AddDecorator(IDecorator<ICardType> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICardType> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ICardType

    public CardType CardType => Item.CardType;
    public bool IsCardType(CardType cardType) => Item.IsCardType(cardType);

    #endregion

    public static ICardTypeFacade Get(CardType cardType) => new CardTypeFacade(CardTypeComponent.Get(cardType));
}