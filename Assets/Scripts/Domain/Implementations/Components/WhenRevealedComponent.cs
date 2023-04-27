public sealed class WhenRevealedComponent : IWhenRevealed
{
    public ICommand WhenRevealed { get; private set; }
    private WhenRevealedComponent(ICommand command) => WhenRevealed = command;
    public static IWhenRevealed Get(ICommand command) => new WhenRevealedComponent(command);
}