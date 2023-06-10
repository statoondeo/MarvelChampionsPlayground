using System.Collections;

public interface ICostComponent : ICardComponent<ICostComponent>
{
    int Cost { get; }
    void Play();
    IEnumerator Resolve();
}
