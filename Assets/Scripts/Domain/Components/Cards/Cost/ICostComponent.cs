public interface ICostComponent : ICardComponent<ICostComponent>
{
    int Cost { get; }
    void Play();
    void Resolve();
}
