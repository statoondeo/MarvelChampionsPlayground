using System.Collections;

public sealed class PlayCardCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private PlayCardCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        Game.Enqueue(
            CompositeCommand.Get(
                Game,
                TransactionCommand.Get(Game, MoveToCommand.Get(Game, Card, "STACK")),
                TransactionCommand.Get(Game, ResolveCardCommand.Get(Game, Card))));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, ICard card) => new PlayCardCommand(game, card);
}

