using System.Collections.Generic;
using System.Linq;

public sealed class BoardMulligansCommand : BaseCommand
{
    private BoardMulligansCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(MulliganCommand.Get(Game, item.Id)));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new BoardMulligansCommand(game);
}