using System.Collections.Generic;
using System.Linq;

public sealed class BoardDrawUpToHandCommand : BaseCommand
{
    private readonly ICommand Command;
    private BoardDrawUpToHandCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(DrawUpToHandCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new BoardDrawUpToHandCommand(game);
}