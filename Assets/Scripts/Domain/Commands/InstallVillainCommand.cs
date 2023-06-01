using System.Collections;
using System.Linq;

public sealed class InstallVillainCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private InstallVillainCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        Game.GetAll(VillainIdentitySelector.Get(PlayerId)).ToList()
            .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "BATTLEFIELD")));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string playerId) => new InstallVillainCommand(game, playerId);
}
