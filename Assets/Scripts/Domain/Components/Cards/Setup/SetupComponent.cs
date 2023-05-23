using System;

public sealed class SetupComponent : BaseCardComponent<ISetupComponent>, ISetupComponent
{
    private readonly Func<ICard, ICommand> CommandFactory;
    private ICommand Command;
    public ICommand Setup => Command is null ? Command = CommandFactory.Invoke(Card) : Command;
    private SetupComponent(Func<ICard, ICommand> commandFactory) : base() => CommandFactory = commandFactory;
    public static ISetupComponent Get(Func<ICard, ICommand> commandFactory) => new SetupComponent(commandFactory);
}
