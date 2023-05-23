using System.Collections.Generic;
using System.Linq;

public sealed class BoardInstallVillainCommand : BaseCommand
{
    private BoardInstallVillainCommand(IGame game) : base(game) { }
    public override void Execute()
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => commands.Add(InstallVillainCommand.Get(Game, item.Id)));
        CompositeCommand.Get(commands.ToArray()).Execute();
    }

    public static ICommand Get(IGame game) => new BoardInstallVillainCommand(game);
}
