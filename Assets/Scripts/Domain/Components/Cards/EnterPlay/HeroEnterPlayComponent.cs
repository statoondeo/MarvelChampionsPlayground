public sealed class HeroEnterPlayComponent : BaseEnterPlayComponent
{
    private HeroEnterPlayComponent() : base() { }
    public override void EnterPlay()
    {
        Card.FlipTo(0);
        Card.GetFacade<ILifeComponent>().Init();
    }

    public static IEnterPlayComponent Get() => new HeroEnterPlayComponent();
}
