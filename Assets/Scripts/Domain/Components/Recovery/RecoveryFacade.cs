public sealed class RecoveryFacade : BaseFacade<IRecoveryComponent>, IRecoveryFacade
{
    private RecoveryFacade(IRecoveryComponent item) : base(item) { }
    public int Recovery => Item.Recovery;
    public static IRecoveryFacade Get(int recovery) => new RecoveryFacade(RecoveryComponent.Get(recovery));
}