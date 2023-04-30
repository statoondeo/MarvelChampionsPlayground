public interface ITapComponent : IComponent<ITapComponent>
{
    bool Tapped { get; }
    void Tap();
    void UnTap();
}
