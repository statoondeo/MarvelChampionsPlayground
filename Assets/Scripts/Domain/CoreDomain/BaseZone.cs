using System.Collections.Generic;
using System.Linq;

public abstract class BaseZone : BaseEntity, IZone
{
    protected readonly IRepository<ICard> Cards;
    public string Id { get; private set; }
    public string Label { get; private set; }
    public string OwnerId { get; private set; }


    protected BaseZone(IGame game, string id, string label, string ownerId) : base(game)
    {
        Cards = new CardRepository();
        Id = id;
        Label = label;
        OwnerId = ownerId;
    }
    public ICard GetFirst(ISelector<ICard> selector) => Cards.GetFirst(selector);
    public int Count(ISelector<ICard> selector) => Cards.Count(selector);
    public bool Contains(ICard card) => Cards.Contains(card);
    public void Add(ICard card)
    {
        if (Contains(card)) return;
        IZone previousZone = Game.GetFirst(ZoneIdSelector.Get(card.Location));
        previousZone?.Remove(card);
        card.SetOrder(Cards.Count(NoFilterCardSelector.Get()));
        Cards.Add(card);
        card.SetLocation(Id);
        //Game.Raise(Events.OnAdded, new OnAddedEventModelArg(Id, card));
    }
    public void Remove(ICard card)
    {
        if (!Contains(card)) return;
        Cards.Remove(card);
        foreach (ICard cardInZone in Cards.GetAll(NoFilterCardSelector.Get()))
            if (cardInZone.Order > card.Order) cardInZone.SetOrder(cardInZone.Order - 1);
        //Game.Raise(Events.OnRemoved, new OnRemovedEventModelArg(Id, card));
    }
    public void Shuffle()
    {
        List<ICard> cards = Cards.GetAll(NoFilterCardSelector.Get()).ToList();
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int j = UnityEngine.Random.Range(i + 1, cards.Count - 1);
            int order = cards[i].Order;
            cards[i].FlipTo("BACK");
            cards[i].SetOrder(cards[j].Order);
            cards[j].SetOrder(order);
        }
    }
    public ICard GetLast() => Cards.GetFirst(CardOrderSelector.Get(Cards.Count(NoFilterCardSelector.Get())));
    public ICard GetAt(int index) => Cards.GetFirst(CardOrderSelector.Get(index));
    public IEnumerable<ICard> GetAll(ISelector<ICard> selector) => Cards.GetAll(selector);
}