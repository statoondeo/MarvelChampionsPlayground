using System.Collections.Generic;
using System.Linq;

public sealed class BoardHeroSetupCommand : BaseCommand
{
    private readonly ICommand Command;
    private BoardHeroSetupCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(HeroSetupCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new BoardHeroSetupCommand(game);
}