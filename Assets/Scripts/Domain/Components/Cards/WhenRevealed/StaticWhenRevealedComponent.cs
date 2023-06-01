public sealed class StaticWhenRevealedComponent : BaseWhenRevealedComponent
{
    public override void Reveal() => Card.Game.Enqueue(WhenRevealed);
    private StaticWhenRevealedComponent(ICommand command) : base(command) { }

    public static IWhenRevealedComponent Get(ICommand command)
        => new StaticWhenRevealedComponent(command);
}
