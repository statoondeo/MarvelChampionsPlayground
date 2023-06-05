public abstract class BaseStateBasedCommand : IStateBasedCommand
{
    protected readonly IGame Game;
    protected ICommand LastCommand;
    protected BaseStateBasedCommand(IGame game) => Game = game;

    protected abstract bool Check();
    protected abstract ICommand GetCommand();
    public bool Execute()
    {
        if (!Game.IsCommandInQueue(LastCommand) && Check())
        {
            Game.Enqueue(LastCommand = TransactionCommand.Get(Game, GetCommand()));
            return true;
        }
        return false;
    }
}
