using System.Collections.Generic;

public sealed class OwnerIdSelector : ISelector<ICard>
{
    private readonly string OwnerId;
    private OwnerIdSelector(string ownerId) => OwnerId = ownerId;
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        foreach (ICard card in cards)
            if (card.OwnerId.Equals(OwnerId)) yield return card;
    }
    public static ISelector<ICard> Get(string ownerId) => new OwnerIdSelector(ownerId);
}
