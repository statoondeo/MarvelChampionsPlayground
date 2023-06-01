using System.Collections;

public abstract class BaseCommand : ICommand
{
    protected readonly IGame Game;
    protected BaseCommand(IGame game)
    {
        InProgress = false;
        Executed = false;
        Game = game;
    }
    public bool InProgress { get; protected set; }
    public bool Executed { get; protected set; }
    public abstract IEnumerator Execute();
}

