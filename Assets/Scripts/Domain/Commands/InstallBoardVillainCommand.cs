using System.Collections.Generic;
using System.Linq;

public sealed class InstallBoardVillainCommand : BaseCommand
{
    private readonly ICommand Command;
    private InstallBoardVillainCommand(IGame game) : base(game)
    {
        List<ICommand> commands = new();
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => commands.Add(InstallHeroCommand.Get(Game, item.Id)));
        Command = CompositeCommand.Get(commands.ToArray());
    }
    public override void Execute() => Command.Execute();
    public static ICommand Get(IGame game) => new InstallBoardVillainCommand(game);
}
