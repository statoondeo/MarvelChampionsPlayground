using System.Collections.Generic;

public sealed class PlayerTypeSelector : ISelector<IPlayer>
{
    private readonly HeroType HeroType;
    private PlayerTypeSelector(HeroType heroType) => HeroType = heroType;
    public IEnumerable<IPlayer> Select(IEnumerable<IPlayer> items)
    {
        foreach (IPlayer item in items) if (item.HeroType.Equals(HeroType)) yield return item;
    }
    public static ISelector<IPlayer> Get(HeroType heroType) => new PlayerTypeSelector(heroType);
}