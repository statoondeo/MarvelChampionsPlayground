using System.Collections.Generic;
using System.Linq;

public sealed class SetAsidePlayersObligationsCommand : BaseCommand
{
    private readonly ICommand Command;
    private SetAsidePlayersObligationsCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(SetAsidePlayerObligationsCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new SetAsidePlayersObligationsCommand(game);
}
