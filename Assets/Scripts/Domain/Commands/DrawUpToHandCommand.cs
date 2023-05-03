public sealed class DrawUpToHandCommand : BaseCommand
{
    private readonly string PlayerId;
    private DrawUpToHandCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    public override void Execute()
    {
        IPlayer player = Game.GetFirst(PlayerIdSelector.Get(PlayerId));
        int handCardCount = player.GetZone("HAND").Count(NoFilterCardSelector.Get());
        int handSize = (player.HeroCard.CurrentFace as IHandSizeFacade).HandSize;
        int cardToDraw = handSize - handCardCount;
        if (cardToDraw <= 0) return;
        player.Draw(cardToDraw);
    }

    public static ICommand Get(IGame game, string playerId) => new DrawUpToHandCommand(game, playerId);
}
