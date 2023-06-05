using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class PlayerDiscardHandCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private PlayerDiscardHandCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        IPlayerActor player = Game.GetFirst(PlayerIdSelector.Get(PlayerId)) as IPlayerActor;
        IEnumerable<ICard> cards = player.GetZone("HAND").GetAll(NoFilterCardSelector.Get());
        IList<ICommand> discardCommands = new List<ICommand>();
        cards.ToList().ForEach(card => discardCommands.Add(MoveToCommand.Get(Game, card, "DISCARD")));
        Game.Enqueue(CompositeCommand.Get(Game, discardCommands.ToArray()));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, string playerId) => new PlayerDiscardHandCommand(game, playerId);
}
