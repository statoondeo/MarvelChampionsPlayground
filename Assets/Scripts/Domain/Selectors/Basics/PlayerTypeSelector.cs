public sealed class PlayerTypeSelector : ISelector<IPlayer>
{
    private readonly HeroType HeroType;
    private PlayerTypeSelector(HeroType heroType) => HeroType = heroType;
    public bool Match(IPlayer player) => HeroType.Equals(player.HeroType);
    public static ISelector<IPlayer> Get(HeroType heroType) => new PlayerTypeSelector(heroType);
}
