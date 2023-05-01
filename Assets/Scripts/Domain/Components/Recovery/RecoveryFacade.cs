public sealed class RecoveryFacade : BaseComponentFacade<IRecoveryComponent>, IRecoveryFacade
{
    private RecoveryFacade(IRecoveryComponent item) :base(item) { }

    #region IRecovery

    public int Recovery => Item.Recovery;

    #endregion

    public static IRecoveryFacade Get(int recovery) => new RecoveryFacade(RecoveryComponent.Get(recovery));
}