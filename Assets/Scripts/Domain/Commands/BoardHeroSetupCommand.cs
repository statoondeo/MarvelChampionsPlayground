using System.Collections.Generic;
using System.Linq;

public sealed class BoardHeroSetupCommand : BaseCommand
{
    private BoardHeroSetupCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => commands.Add(HeroSetupCommand.Get(Game, item.Id)));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new BoardHeroSetupCommand(game);
}