public sealed class TapCommand : BaseCommand
{
    private readonly ICard Card;
    private TapCommand(IGame game, ICard card) : base(game) => Card = card;
    public override void Execute() => Card.Tap();
    public static ICommand Get(IGame game, ICard card) => new TapCommand(game, card);
}
