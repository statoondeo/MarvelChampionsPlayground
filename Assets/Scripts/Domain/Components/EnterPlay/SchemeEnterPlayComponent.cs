public sealed class SchemeEnterPlayComponent : BaseEnterPlayComponent
{
    private SchemeEnterPlayComponent() : base() { }
    public override void EnterPlay()
    {
        Card.Tap();
        Card.GetFacade<ITreatComponent>()?.Init();
    }
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        Card.AddListener<IFlipComponent>(OnFlipChanged);
    }
    private void OnFlipChanged(IComponent component)
    {
        if (!Card.IsLocation("BATTLEFIELD")) return;
        EnterPlay();
    }
    public static IEnterPlayComponent Get() => new SchemeEnterPlayComponent();
}
