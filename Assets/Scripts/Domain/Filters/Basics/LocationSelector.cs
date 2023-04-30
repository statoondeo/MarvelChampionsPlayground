using System.Collections.Generic;

public sealed class LocationSelector : ISelector<ICard>
{
    private readonly string Location;
    private LocationSelector(string location) => Location = location;
    public IEnumerable<ICard> Select(IEnumerable<ICard> cards)
    {
        foreach (ICard card in cards)
            if (card.IsLocation(Location)) yield return card;
    }
    public static ISelector<ICard> Get(string location) => new LocationSelector(location);
}
