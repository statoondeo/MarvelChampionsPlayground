public sealed class WhenRevealedComponent : BaseComponent<IWhenRevealedComponent>, IWhenRevealedComponent
{
    public ICommand WhenRevealed { get; private set; }
    private WhenRevealedComponent(ICommand command) : base() => WhenRevealed = command;
    public static IWhenRevealedComponent Get(ICommand command) => new WhenRevealedComponent(command);
}
