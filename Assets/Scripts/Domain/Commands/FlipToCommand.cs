using System.Collections;

public sealed class FlipToCommand : BaseSingleCommand
{
    private readonly int Face;
    private readonly ICard Card;
    private FlipToCommand(IGame game, ICard card, int face) : base(game)
    {
        Face = face;
        Card = card;
    }
    public override IEnumerator Execute()
    {
        Card.FlipTo(Face);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ICard card, int face) => new FlipToCommand(game, card, face);
}
