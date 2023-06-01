public sealed class InstantWhenRevealedComponent : BaseWhenRevealedComponent
{
    public override void Reveal()
    {
        Card.MoveTo("STACK");
        Card.Game.Enqueue(CompositeCommand.Get(Card.Game, WhenRevealed, MoveToCommand.Get(Card.Game, Card, "DISCARD")));
    }
    private InstantWhenRevealedComponent(ICommand command) : base(command) { }

    public static IWhenRevealedComponent Get(ICommand command)
        => new InstantWhenRevealedComponent(command);
}
