using System.Collections;
using System.Linq;

using UnityEngine;

public sealed class InstallHeroCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private InstallHeroCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerIdentitySelector.Get(PlayerId)).ToList()
            .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "BATTLEFIELD")));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string playerId) => new InstallHeroCommand(game, playerId);
}
