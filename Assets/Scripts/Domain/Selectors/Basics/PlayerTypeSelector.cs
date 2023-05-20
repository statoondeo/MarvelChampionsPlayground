public sealed class PlayerTypeSelector : ISelector<IActor>
{
    private readonly HeroType HeroType;
    private PlayerTypeSelector(HeroType heroType) => HeroType = heroType;
    public bool Match(IActor player) => HeroType.Equals(player.HeroType);
    public static ISelector<IActor> Get(HeroType heroType) => new PlayerTypeSelector(heroType);
}
