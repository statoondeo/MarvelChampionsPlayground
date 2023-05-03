using System.Collections.Generic;
using System.Linq;

public sealed class ShufflePlayersDecksCommand : BaseCommand
{
    private readonly ICommand Command;
    public ShufflePlayersDecksCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(ShuffleZoneCommand.Get(Game, item.GetZone("DECK"))));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new ShufflePlayersDecksCommand(game);
}
