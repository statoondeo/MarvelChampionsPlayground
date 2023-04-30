using System;

public sealed class RecoveryFacade : IRecoveryFacade
{
    private readonly IFacade<IRecoveryComponent> Facade;
    private RecoveryFacade(IRecoveryComponent item) => Facade = FacadeComponent<IRecoveryComponent>.Get(item);

    #region IFacade<IRecovery>

    public IRecoveryComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IRecoveryComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IRecoveryComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IRecovery

    public Action<IRecoveryComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Recovery => Item.Recovery;

    #endregion

    public static IRecoveryFacade Get(int recovery) => new RecoveryFacade(RecoveryComponent.Get(recovery));
}