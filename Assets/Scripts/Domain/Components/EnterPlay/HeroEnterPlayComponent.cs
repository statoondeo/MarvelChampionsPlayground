public sealed class HeroEnterPlayComponent : BaseEnterPlayComponent
{
    private HeroEnterPlayComponent() : base() { }
    public override void EnterPlay()
    {
        Card.FlipTo("FACE");
        Card.GetFacade<ILifeComponent>().Init();
    }

    public static IEnterPlayComponent Get() => new HeroEnterPlayComponent();
}
