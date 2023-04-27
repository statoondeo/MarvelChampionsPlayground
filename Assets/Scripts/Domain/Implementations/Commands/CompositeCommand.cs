using System.Collections.Generic;

public sealed class CompositeCommand : ICommand
{
    private readonly IEnumerable<ICommand> Commands;
    private CompositeCommand(IEnumerable<ICommand> commands) => Commands = commands;
    public void Execute()
    {
        foreach (ICommand command in Commands) command.Execute();
    }
    public static ICommand Get(params ICommand[] commands) => new CompositeCommand(commands);
}
