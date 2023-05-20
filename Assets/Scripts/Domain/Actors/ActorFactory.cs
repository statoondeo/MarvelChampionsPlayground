public sealed class ActorFactory
{
    public IActor Create(IGame game, string id, string name, HeroType heroType)
    {
        return heroType switch
        {
            HeroType.Hero => PlayerActor.Get(game, id, name, heroType),
            HeroType.Villain => VillainActor.Get(game, id, name, heroType),
            _ => null
        };
    }
}