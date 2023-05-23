using System.Collections.Generic;
using System.Linq;

public sealed class BoardSetAsideObligationsCommand : BaseCommand
{
    private BoardSetAsideObligationsCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new List<ICommand>();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(SetAsideObligationsCommand.Get(Game, item.Id)));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new BoardSetAsideObligationsCommand(game);
}
