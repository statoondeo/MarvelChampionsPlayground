public sealed class StaticWhenRevealedComponent : BaseWhenRevealedComponent
{
    public override void Reveal() => WhenRevealed.Execute();
    private StaticWhenRevealedComponent(ICommand command) : base(command) { }

    public static IWhenRevealedComponent Get(ICommand command)
        => new StaticWhenRevealedComponent(command);
}
