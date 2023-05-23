using System.Collections.Generic;
using System.Linq;

public sealed class ShuffleVillainsDecksCommand : BaseCommand
{
    public ShuffleVillainsDecksCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new List<ICommand>();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => commands.Add(ShuffleZoneCommand.Get(Game, item.GetZone("DECK"))));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new ShuffleVillainsDecksCommand(game);
}
