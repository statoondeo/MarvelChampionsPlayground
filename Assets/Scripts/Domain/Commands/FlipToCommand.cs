public sealed class FlipToCommand : BaseCommand
{
    private readonly int Face;
    private readonly ICard Card;
    private FlipToCommand(IGame game, ICard card, int face) : base(game)
    {
        Face = face;
        Card = card;
    }
    public override void Execute() => Card.FlipTo(Face);
    public static ICommand Get(IGame game, ICard card, int face) => new FlipToCommand(game, card, face);
}
