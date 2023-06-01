using System.Collections;

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
        for (int i = 0; i < cardToDraw; i++) Game.Enqueue(DrawCommand.Get(Game, player));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, string playerId) => new PlayerDrawUpToHandCommand(game, playerId);
}
