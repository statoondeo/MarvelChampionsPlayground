public sealed class RecoveryFacade : BaseCardComponentFacade<IRecoveryComponent>, IRecoveryFacade
{
    private RecoveryFacade(IRecoveryComponent item) : base(item) { }
    public int Recovery => Item.Recovery;
    public static IRecoveryFacade Get(int recovery) => new RecoveryFacade(RecoveryComponent.Get(recovery));
}