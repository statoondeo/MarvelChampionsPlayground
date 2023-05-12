public sealed class PermanentResetComponent : BaseResetComponent
{
    private PermanentResetComponent() : base() { }
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<ILocationComponent>(OnChangedCallback);
    }
    private void OnChangedCallback(IComponent component)
    {
        if (!Card.IsLocation("BATTLEFIELD")) return;
        Reset();
    }
    public static IResetComponent Get()
        => new PermanentResetComponent();
}