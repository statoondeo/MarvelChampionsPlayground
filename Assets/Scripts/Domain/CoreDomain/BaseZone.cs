using System;
using System.Collections.Generic;
using System.Linq;

public abstract class BaseZone : BaseEntity, IZone
{
    protected readonly List<ICard> Cards;
    public string Id { get; private set; }
    public string Label { get; private set; }
    public string OwnerId { get; private set; }
    public int Count => Cards.Count;
    public Action<ICard> OnCardAdded { get; set; }
    public Action<ICard> OnCardRemoved { get; set; }
    public Action OnShuffled { get; set; }

    protected BaseZone(IGame game, string id, string label, string ownerId) : base(game)
    {
        Cards = new List<ICard>();
        Id = id;
        Label = label;
        OwnerId = ownerId;
    }
    public void AddCard(ICard card)
    {
        if (ContainsCard(card)) return;
        if (Game.Zones.TryGetValue(card.Location, out IZone previousZone)) previousZone.RemoveCard(card);
        card.SetOrder(Cards.Count);
        Cards.Add(card);
        card.SetLocation(Id);
        OnCardAdded?.Invoke(card);
        Game.Mediator.Raise(Events.OnAdded, new OnAddedEventModelArg(Id, card));
    }
    public void RemoveCard(ICard card)
    {
        if (!ContainsCard(card)) return;
        Cards.Remove(card);
        foreach (ICard cardInZone in Cards)
            if (cardInZone.Order > card.Order) cardInZone.SetOrder(cardInZone.Order - 1);
        OnCardRemoved?.Invoke(card);
        Game.Mediator.Raise(Events.OnRemoved, new OnRemovedEventModelArg(Id, card));
    }
    public bool ContainsCard(ICard card) => Cards.Contains(card);
    public void Shuffle()
    {
        for (int i = 0; i < Cards.Count - 1; i++)
        {
            int j = UnityEngine.Random.Range(i + 1, Cards.Count - 1);
            int order = Cards[i].Order;
            Cards[i].FlipTo("BACK");
            Cards[i].SetOrder(Cards[j].Order);
            Cards[j].SetOrder(order);
        }
        OnShuffled?.Invoke();
    }
    public ICard First() => OrderedCards.FirstOrDefault();
    public ICard Last() => OrderedCards.LastOrDefault();
    public ICard GetAt(int index) => OrderedCards.ElementAtOrDefault(index);
    public IEnumerator<ICard> GetEnumerator() => OrderedCards.GetEnumerator();
    private List<ICard> OrderedCards => Cards.OrderBy(item => item.Order).ToList();

}