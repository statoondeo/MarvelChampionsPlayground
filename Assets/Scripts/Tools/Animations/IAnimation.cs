using System.Collections;

public interface IAnimation
{
    bool InProgress { get; }
    bool Ended { get; }
    public IEnumerator Start();
}
