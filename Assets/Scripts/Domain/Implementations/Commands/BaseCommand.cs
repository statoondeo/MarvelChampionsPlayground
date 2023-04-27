public abstract class BaseCommand : ICommand
{
    protected readonly IGame Game;
    protected BaseCommand(IGame game) => Game = game;
    public abstract void Execute();
}
