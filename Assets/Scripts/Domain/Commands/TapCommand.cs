using System.Collections;

public sealed class TapCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private TapCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        Card.Tap();
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ICard card) => new TapCommand(game, card);
}
