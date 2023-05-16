public sealed class SchemeAEnterPlayComponent : BaseEnterPlayComponent
{
    private SchemeAEnterPlayComponent() : base() { }
    public override void EnterPlay() => Card.Tap();
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
    public static IEnterPlayComponent Get() => new SchemeAEnterPlayComponent();
}