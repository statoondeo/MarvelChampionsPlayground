public interface ITapComponent : ICardComponent<ITapComponent>
{
    bool Tapped { get; }
    void Tap();
    void UnTap();
}
