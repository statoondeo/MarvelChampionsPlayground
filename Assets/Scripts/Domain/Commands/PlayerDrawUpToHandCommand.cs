public sealed class PlayerDrawUpToHandCommand : BaseCommand
{
    private readonly string PlayerId;
    private PlayerDrawUpToHandCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override void Execute()
    {
        IPlayerActor player = Game.GetFirst(PlayerIdSelector.Get(PlayerId)) as IPlayerActor;
        int handCardCount = player.GetZone("HAND").Count(NoFilterCardSelector.Get());
        int handSize = (player.HeroCard.CurrentFace as IHandSizeFacade).HandSize;
        int cardToDraw = handSize - handCardCount;
        if (cardToDraw <= 0) return;
        player.Draw(cardToDraw);
    }

    public static ICommand Get(IGame game, string playerId) => new PlayerDrawUpToHandCommand(game, playerId);
}
