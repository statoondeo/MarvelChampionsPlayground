public sealed class SetupFacade : BaseCardComponentFacade<ISetupComponent>, ISetupFacade
{
    private SetupFacade(ISetupComponent item) : base(item) { }
    public ICommand Setup => Item.Setup;
    public static ISetupFacade Get(ICommand command) => new SetupFacade(SetupComponent.Get(command));
}