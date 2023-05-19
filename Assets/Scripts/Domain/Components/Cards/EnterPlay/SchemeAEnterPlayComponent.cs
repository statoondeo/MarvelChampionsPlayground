public sealed class SchemeAEnterPlayComponent : BaseEnterPlayComponent
{
    private SchemeAEnterPlayComponent() : base() { }
    public override void EnterPlay()
    {
        Card.FlipTo(0);
        Card.Tap();
    }
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IFlipComponent>(OnFlipChanged);
    }
    private void OnFlipChanged(IComponent component)
    {
        if (!Card.IsLocation("BATTLEFIELD")) return;
        if (!Card.IsFace(0)) return;
        EnterPlay();
    }
    public static IEnterPlayComponent Get() => new SchemeAEnterPlayComponent();
}
