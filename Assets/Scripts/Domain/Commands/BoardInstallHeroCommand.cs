using System.Collections;
using System.Linq;

using UnityEngine;

public sealed class BoardInstallHeroCommand : BaseSingleCommand
{
    private BoardInstallHeroCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => Game.Enqueue(InstallHeroCommand.Get(Game, item.Id)));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new BoardInstallHeroCommand(game);
}
