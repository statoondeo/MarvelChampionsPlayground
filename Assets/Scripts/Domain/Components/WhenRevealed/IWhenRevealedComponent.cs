public interface IWhenRevealedComponent : IComponent<IWhenRevealedComponent>
{
    void Reveal();
    ICommand WhenRevealed { get; }
}
