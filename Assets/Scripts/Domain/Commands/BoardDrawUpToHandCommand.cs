using System.Collections.Generic;
using System.Linq;

public sealed class BoardDrawUpToHandCommand : BaseCommand
{
    private BoardDrawUpToHandCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(PlayerDrawUpToHandCommand.Get(Game, item.Id)));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new BoardDrawUpToHandCommand(game);
}