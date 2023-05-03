using System.Collections.Generic;
using System.Linq;

public sealed class ShuffleVillainsDecksCommand : BaseCommand
{
    private readonly ICommand Command;
    public ShuffleVillainsDecksCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new List<ICommand>();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => commands.Add(ShuffleZoneCommand.Get(Game, item.GetZone("DECK"))));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new ShuffleVillainsDecksCommand(game);
}
