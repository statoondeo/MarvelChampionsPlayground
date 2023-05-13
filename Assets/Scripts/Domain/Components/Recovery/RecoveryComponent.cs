public sealed class RecoveryComponent : BaseComponent<IRecoveryComponent>, IRecoveryComponent
{
    public int Recovery { get; private set; }
    private RecoveryComponent(int recovery) : base()
    {
        Recovery = recovery;
    }
    public static IRecoveryComponent Get(int recovery) => new RecoveryComponent(recovery);
}
