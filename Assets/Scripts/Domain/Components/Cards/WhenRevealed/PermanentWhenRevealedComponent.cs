public sealed class PermanentWhenRevealedComponent : BaseWhenRevealedComponent
{
    public override void Reveal()
    {
        Card.MoveTo("BATTLEFIELD");
        Card.Game.Enqueue(WhenRevealed);
    }
    private PermanentWhenRevealedComponent(ICommand command) : base(command) { }

    public static IWhenRevealedComponent Get(ICommand command)
        => new PermanentWhenRevealedComponent(command);
}
