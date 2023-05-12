public sealed class BasicResetComponent : BaseResetComponent
{
    private BasicResetComponent() : base() { }
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IFlipComponent>(OnChangedCallback);
        Card.AddListener<ILocationComponent>(OnChangedCallback);
    }
    private void OnChangedCallback(IComponent component)
    {
        if (!Card.IsLocation("BATTLEFIELD")) return;
        if (!Card.IsFace("FACE")) return;
        Reset();
    }
    public static IResetComponent Get()
        => new BasicResetComponent();
}
