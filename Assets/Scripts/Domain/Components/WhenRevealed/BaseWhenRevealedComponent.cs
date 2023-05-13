public abstract class BaseWhenRevealedComponent : BaseComponent<IWhenRevealedComponent>, IWhenRevealedComponent
{
    protected BaseWhenRevealedComponent(ICommand command) : base()
    {
        WhenRevealed = command;
    }
    public ICommand WhenRevealed { get; protected set; }
    public abstract void Reveal();
}