using System;
using System.Collections.Generic;

public interface IZone : IEntity
{
    string Id { get; }
    string Label { get; }
    string OwnerId { get; }
    int Count { get; }

    void AddCard(ICard card);
    bool ContainsCard(ICard card);
    void RemoveCard(ICard card);
    void Shuffle();

    ICard First();
    ICard Last();
    ICard GetAt(int index);
    IEnumerator<ICard> GetEnumerator();

    Action OnShuffled { get; set; }
    Action<ICard> OnCardAdded { get; set; }
    Action<ICard> OnCardRemoved { get; set; }
}
