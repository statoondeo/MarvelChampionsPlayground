using System;
using System.Collections;
using System.Linq;

public sealed class SetAsideNemesisSetCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private SetAsideNemesisSetCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerNemesisSetSelector.Get(PlayerId)).ToList()
            .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "EXIL")));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string playerId) => new SetAsideNemesisSetCommand(game, playerId);
}
