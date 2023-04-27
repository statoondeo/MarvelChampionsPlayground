public sealed class RecoveryComponent : IRecovery
{
    public int Recovery { get; private set; }
    private RecoveryComponent(int recovery) => Recovery = recovery;
    public static IRecovery Get(int recovery) => new RecoveryComponent(recovery);
}
public interface IRecoveryFacade : IFacade<IRecovery>, IRecovery { }
public sealed class RecoveryFacade : IRecoveryFacade
{
    private readonly IFacade<IRecovery> Facade;
    private RecoveryFacade(IRecovery item) => Facade = FacadeComponent<IRecovery>.Get(item);

    #region IFacade<IRecovery>

    public IRecovery Item { get; private set; }
    public void AddDecorator(IDecorator<IRecovery> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IRecovery> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IRecovery

    public int Recovery => Item.Recovery;

    #endregion

    public static IRecoveryFacade Get(int recovery) => new RecoveryFacade(RecoveryComponent.Get(recovery));
}