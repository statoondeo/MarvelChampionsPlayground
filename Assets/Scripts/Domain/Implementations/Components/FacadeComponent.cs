using System;

public sealed class FacadeComponent<T> : IFacade<T>
{
    public T Item { get; private set; }
    private FacadeComponent(T item) => Item = item;
    public void AddDecorator(IDecorator<T> decorator) => Item = decorator.Wrap(Item);
    public void RemoveDecorator(IDecorator<T> decorator)
    {
        IDecorator<T> previous = null;
        IDecorator<T> current = Item as IDecorator<T>;
        while (current is not null)
        {
            if (current != decorator)
            {
                previous = current;
                current = current.Inner as IDecorator<T>;
                continue;
            }
            if (previous is null)
            {
                Item = current.Inner;
                break;
            }
            previous.Wrap(current.Inner);
            break;
        }
    }
    public static IFacade<T> Get(T item) => new FacadeComponent<T>(item);
}
public sealed class CardFacade : ICardFacade
{
    private readonly IFacade<ICard> CardFacadeComponent;
    private CardFacade(ICard card) => CardFacadeComponent = FacadeComponent<ICard>.Get(card);

    #region IFacade<ICard>

    public ICard Item { get; private set; }
    public void AddDecorator(IDecorator<ICard> decorator) => CardFacadeComponent.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ICard> decorator) => CardFacadeComponent.RemoveDecorator(decorator);

    #endregion

    #region ICard

    public IGame Game => Item.Game;
    public string CardId => Item.CardId;
    public string Id => Item.Id;
    public string OwnerId => Item.OwnerId;
    public string Location => Item.Location;
    public int Order => Item.Order;
    public CardType CardType => Item.CardType;
    public IFace CurrentFace => Item.CurrentFace;
    public IRepository<string, IFace> Faces => Item.Faces;
    public bool Tapped => Item.Tapped;
    public Classification Classification => Item.Classification;

    public Action<bool> OnTapped { get => Item.OnTapped; set => Item.OnTapped = value; }
    public Action<bool> OnUnTapped { get => Item.OnUnTapped; set => Item.OnUnTapped = value; }
    public Action<string> OnFlipped { get => Item.OnFlipped; set => Item.OnFlipped = value; }
    public Action<string> OnLocationChanged { get => Item.OnLocationChanged; set => Item.OnLocationChanged = value; }
    public Action<int> OnOrderChanged { get => Item.OnOrderChanged; set => Item.OnOrderChanged = value; }

    public bool IsClassification(Classification classification) => Item.IsClassification(classification);
    public bool IsCardType(CardType cardType) => Item.IsCardType(cardType);
    public bool IsLocation(string location) => Item.IsLocation(location);
    public void SetLocation(string newLocation) => Item.SetLocation(newLocation);
    public void SetOrder(int newOrder) => Item.SetOrder(newOrder);

    public void Tap() => Item.Tap();
    public void UnTap() => Item.UnTap();
    public void FlipTo(string face) => Item.FlipTo(face);
    public void MoveTo(string location) => Item.MoveTo(location);

    #endregion

    public static ICard Get(ICard card) => new CardFacade(card);
}