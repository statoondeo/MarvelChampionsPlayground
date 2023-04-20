using System;

public sealed class TappedComponent : ITapped
{
    public bool Tapped {get; private set;}
    public TappedComponent(bool tapped) => Tapped = tapped;
    public Action<bool> OnTapped { get; set; }
    public Action<bool> OnUnTapped { get; set; }
    public void Tap()
    {
        if (Tapped) return;
        Tapped = true;
        OnTapped?.Invoke(Tapped);
    }
    public void UnTap()
    {
        if (!Tapped) return;
        Tapped = false;
        OnUnTapped?.Invoke(Tapped);
    }
}