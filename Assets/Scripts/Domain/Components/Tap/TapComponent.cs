public sealed class TapComponent : BaseComponent<ITapComponent>, ITapComponent
{
    public bool Tapped {get; private set;}
    public TapComponent() : base()
    {
        Type = ComponentType.Tap;
        Tapped = false;
    }
    public void Tap()
    {
        if (Tapped) return;
        Tapped = true;
        Card.Raise(Type);
    }
    public void UnTap()
    {
        if (!Tapped) return;
        Tapped = false;
        Card.Raise(Type);
    }
    public static ITapComponent Get() => new TapComponent();
}
