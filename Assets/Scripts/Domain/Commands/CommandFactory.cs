using System;

public sealed class CommandFactory
{
    private readonly IGame Game;
    public CommandFactory(IGame game) => Game = game;
    public Func<ICard, ICommand> Create(string commandParams)
    {
        string[] paramsArray = commandParams.Split(',');
        return paramsArray[0].Trim().ToUpper() switch
        {
            "FLIPTONEXT" => FlipToNextCommand.GetFactory(Game),
            "HINDER" => HinderCommand.GetFactory(Game, int.Parse(paramsArray[1])),
            "SEARCHANDREVEAL" => SearchAndRevealCommand.GetFactory(Game, paramsArray[1]),
            _ => NullCommand.GetFactory(Game)
        };
    }
}
