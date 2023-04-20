public interface IRecovery { int Recovery { get; } }
public sealed class RecoveryComponent : IRecovery
{
    public int Recovery { get; private set; }
    public RecoveryComponent(int recovery) => Recovery = recovery;
}