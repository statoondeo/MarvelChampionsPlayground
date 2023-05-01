﻿public sealed class TapComponent : BaseComponent<ITapComponent>, ITapComponent
{
    public bool Tapped {get; private set;}
    public TapComponent() : base() => Tapped = false;
    public void Tap()
    {
        if (Tapped) return;
        Tapped = true;
        Notify(this);
    }
    public void UnTap()
    {
        if (!Tapped) return;
        Tapped = false;
        Notify(this);
    }
    public static ITapComponent Get() => new TapComponent();
}
