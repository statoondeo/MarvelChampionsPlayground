using System.Collections.Generic;
using System.Linq;

public sealed class BoardMulligansCommand : BaseCommand
{
    private readonly ICommand Command;
    private BoardMulligansCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(MulliganCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new BoardMulligansCommand(game);
}