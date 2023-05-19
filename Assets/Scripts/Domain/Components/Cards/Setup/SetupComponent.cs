public sealed class SetupComponent : BaseCardComponent<ISetupComponent>, ISetupComponent
{
    public ICommand Setup { get; private set; }
    private SetupComponent(ICommand command) : base()
    {
        Setup = command;
    }
    public static ISetupComponent Get(ICommand command) => new SetupComponent(command);
}
