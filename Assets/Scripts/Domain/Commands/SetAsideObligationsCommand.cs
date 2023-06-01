using System.Collections;
using System.Linq;

public sealed class SetAsideObligationsCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private SetAsideObligationsCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerObligationSelector.Get(PlayerId)).ToList()
            .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "EXIL")));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string playerId) => new SetAsideObligationsCommand(game, playerId);
}
