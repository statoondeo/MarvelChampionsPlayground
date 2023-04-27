public sealed class MoveToCommand : BaseCommand
{
    private readonly string Location;
    private readonly ICard Card;
    private MoveToCommand(IGame game, ICard card, string location) : base(game)
    {
        Location = location;
        Card = card;
    }
    public override void Execute() => Card.MoveTo(Location);
    public static ICommand Get(IGame game, ICard card, string location) => new MoveToCommand(game, card, location);
}
