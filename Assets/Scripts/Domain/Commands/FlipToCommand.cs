public sealed class FlipToCommand : BaseCommand
{
    private readonly string Face;
    private readonly ICard Card;
    private FlipToCommand(IGame game, ICard card, string face) : base(game)
    {
        Face = face;
        Card = card;
    }
    public override void Execute() => Card.FlipTo(Face);
    public static ICommand Get(IGame game, ICard card, string face) => new FlipToCommand(game, card, face);
}
