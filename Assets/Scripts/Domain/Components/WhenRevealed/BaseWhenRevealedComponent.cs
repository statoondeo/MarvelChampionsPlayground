public abstract class BaseWhenRevealedComponent : BaseComponent<IWhenRevealedComponent>, IWhenRevealedComponent
{
    protected BaseWhenRevealedComponent(ICommand command) : base()
    {
        Type = ComponentType.WhenRevealed;
        WhenRevealed = command;
    }
    public ICommand WhenRevealed { get; protected set; }
    public abstract void Reveal();
}