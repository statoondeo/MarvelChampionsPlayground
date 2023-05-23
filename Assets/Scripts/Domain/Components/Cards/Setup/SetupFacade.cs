using System;

public sealed class SetupFacade : BaseCardComponentFacade<ISetupComponent>, ISetupFacade
{
    private SetupFacade(ISetupComponent item) : base(item) { }
    public ICommand Setup => Item.Setup;
    public static ISetupFacade Get(Func<ICard, ICommand> commandFactory) 
        => new SetupFacade(SetupComponent.Get(commandFactory));
}