public sealed class UnTapCommand : BaseCommand
{
    private readonly ICard Card;
    private UnTapCommand(IGame game, ICard card) : base(game) => Card = card;
    public override void Execute() => Card.UnTap();
    public static ICommand Get(IGame game, ICard card) => new UnTapCommand(game, card);
}
