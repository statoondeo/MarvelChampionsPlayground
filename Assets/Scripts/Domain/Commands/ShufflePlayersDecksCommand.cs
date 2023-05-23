using System.Collections.Generic;
using System.Linq;

public sealed class ShufflePlayersDecksCommand : BaseCommand
{
    public ShufflePlayersDecksCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(ShuffleZoneCommand.Get(Game, item.GetZone("DECK"))));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new ShufflePlayersDecksCommand(game);
}
