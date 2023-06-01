using System;
using System.Collections;

public sealed class FlipToNextCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private FlipToNextCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        Card.FlipToNext();
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ICard card) => new FlipToNextCommand(game, card);
    public static Func<ICard, ICommand> GetFactory(IGame game) => (card) => Get(game, card);
}
