using System;

public sealed class CommandFactory
{
    private readonly IGame Game;
    public CommandFactory(IGame game) => Game = game;
    public Func<ICard, ICommand> Create(string commandName)
    {
        return commandName.ToUpper() switch
        {
            "FLIPTONEXT" => FlipToNextCommand.GetFactory(Game),
            _ => NullCommand.GetFactory(Game)
        };
    }
}