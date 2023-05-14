public sealed class AllyEnterPlayComponent : BaseEnterPlayComponent
{
    private AllyEnterPlayComponent() : base() { }
    public override void EnterPlay()
    {
        Card.GetFacade<ILifeComponent>().Init();
    }
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IFlipComponent>(OnFlipChanged);
    }
    private void OnFlipChanged(IComponent component)
    {
        if (!Card.IsLocation("BATTLEFIELD")) return;
        if (!Card.IsFace("FACE")) return;
        EnterPlay();
    }
    public static IEnterPlayComponent Get() => new AllyEnterPlayComponent();
}