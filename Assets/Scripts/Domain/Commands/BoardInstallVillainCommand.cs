using System.Collections;
using System.Linq;

public sealed class BoardInstallVillainCommand : BaseSingleCommand
{
    private BoardInstallVillainCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => Game.Enqueue(InstallVillainCommand.Get(Game, item.Id)));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new BoardInstallVillainCommand(game);
}
