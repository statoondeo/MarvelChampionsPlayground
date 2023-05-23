using System;

public sealed class FlipToNextCommand : BaseCommand
{
    private readonly ICard Card;
    private FlipToNextCommand(IGame game, ICard card) : base(game) => Card = card;
    public override void Execute() => Card.FlipToNext();
    public static ICommand Get(IGame game, ICard card) => new FlipToNextCommand(game, card);
    public static Func<ICard, ICommand> GetFactory(IGame game) 
        => (card) => new FlipToNextCommand(game, card);
}
