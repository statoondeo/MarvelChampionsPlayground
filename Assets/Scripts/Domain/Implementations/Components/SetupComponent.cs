public sealed class SetupComponent : ISetup
{
    public ICommand Setup { get; private set; }
    private SetupComponent(ICommand command) => Setup = command;
    public static ISetup Get(ICommand command) => new SetupComponent(command);
}
public interface ISetupFacade : IFacade<ISetup>, ISetup { }
public sealed class SetupFacade : ISetupFacade
{
    private readonly IFacade<ISetup> Facade;
    private SetupFacade(ISetup item) => Facade = FacadeComponent<ISetup>.Get(item);

    #region IFacade<ISetup>

    public ISetup Item { get; private set; }
    public void AddDecorator(IDecorator<ISetup> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetup> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ISetup

    public ICommand Setup => Item.Setup;

    #endregion

    public static ISetupFacade Get(ICommand command) => new SetupFacade(SetupComponent.Get(command));
}