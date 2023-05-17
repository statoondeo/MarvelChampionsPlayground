public sealed class SingleFaceEnterPlayComponent : BaseEnterPlayComponent
{
    private SingleFaceEnterPlayComponent() : base() { }
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
        if (!Card.IsFace(0)) return;
        EnterPlay();
    }
    public static IEnterPlayComponent Get() => new SingleFaceEnterPlayComponent();
}