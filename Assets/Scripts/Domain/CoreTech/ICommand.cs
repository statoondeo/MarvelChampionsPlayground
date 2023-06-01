using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface ICommand
{
    bool InProgress { get; }
    bool Executed { get; }
    IEnumerator Execute();
}
public abstract class BaseSingleCommand : BaseCommand
{
    protected BaseSingleCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Executed = true;
        yield return null;
    }
}
public sealed class CompositeCommand : BaseComposedCommand
{
    private CompositeCommand(IGame game, params ICommand[] commands) : base(game, commands) { }
    public static ICommand Get(IGame game, params ICommand[] commands) => new CompositeCommand(game, commands);
}
public abstract class BaseComposedCommand : BaseCommand
{
    protected readonly IList<ICommand> Commands;
    protected BaseComposedCommand(IGame game, params ICommand[] commands)
        : base(game) => Commands = commands.ToList();
    public override IEnumerator Execute()
    {
        foreach (ICommand command in Commands)
            if (!command.Executed)
            {
                Game.Enqueue(command);
                yield break;
            }
        Executed = true;
        yield return null;
    }
}
