public sealed class InstantWhenRevealedComponent : BaseWhenRevealedComponent
{
    public override void Reveal()
    {
        Card.MoveTo("STACK");
        CompositeCommand.Get(WhenRevealed, MoveToCommand.Get(Card.Game, Card, "DISCARD")).Execute();
    }
    private InstantWhenRevealedComponent(ICommand command) : base(command) { }

    public static IWhenRevealedComponent Get(ICommand command)
        => new InstantWhenRevealedComponent(command);
}
