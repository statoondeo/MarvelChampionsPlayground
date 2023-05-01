public sealed class SetupFacade : BaseComponentFacade<ISetupComponent>, ISetupFacade
{
    private SetupFacade(ISetupComponent item) : base(item) { }

    #region ISetup

    public ICommand Setup => Item.Setup;

    #endregion

    public static ISetupFacade Get(ICommand command) => new SetupFacade(SetupComponent.Get(command));
}