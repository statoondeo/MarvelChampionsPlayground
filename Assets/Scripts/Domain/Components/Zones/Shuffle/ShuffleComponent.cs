using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public sealed class ShuffleComponent : BaseZoneComponent<IShuffleComponent>, IShuffleComponent
{
    private ShuffleComponent() : base() { }
    public void Shuffle()
    {
        List<ICard> cards = Zone.GetAll(NoFilterCardSelector.Get()).ToList();
        for (int i = 0; i < cards.Count - 1; i++)
        {
            int j = Random.Range(i + 1, cards.Count - 1);
            int order = cards[i].Order;
            cards[i].FlipTo(1);
            cards[i].SetOrder(cards[j].Order);
            cards[j].SetOrder(order);
        }
        Zone.Raise<IShuffleComponent>();
    }
    public static IShuffleComponent Get() => new ShuffleComponent();
}
