using System;

public interface ITapped
{
    bool Tapped { get; }
    void Tap();
    void UnTap();
    Action<bool> OnTapped { get; set; }
    Action<bool> OnUnTapped { get; set; }
}
