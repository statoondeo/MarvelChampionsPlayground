using System.Collections;
using System.Collections.Generic;
using System.Linq;

public sealed class PlayerDrawUpToHandCommand : BaseSingleCommand
{
    private readonly string PlayerId;
    private PlayerDrawUpToHandCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override IEnumerator Execute()
    {
        IPlayerActor player = Game.GetFirst(PlayerIdSelector.Get(PlayerId)) as IPlayerActor;
        int handCardCount = player.GetZone("HAND").Count(NoFilterCardSelector.Get());
        int handSize = (player.HeroCard.CurrentFace as IHandSizeFacade).HandSize;
        int cardToDraw = handSize - handCardCount;
        IList<ICommand> drawCommands = new List<ICommand>();
        for(int i = 0; i < cardToDraw; i++) 
            drawCommands.Add(DrawCommand.Get(Game, player));
        Game.Enqueue(CompositeCommand.Get(Game, drawCommands.ToArray()));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, string playerId) => new PlayerDrawUpToHandCommand(game, playerId);
}
