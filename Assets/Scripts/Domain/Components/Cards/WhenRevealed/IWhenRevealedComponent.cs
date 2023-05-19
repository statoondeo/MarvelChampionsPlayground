public interface IWhenRevealedComponent : ICardComponent<IWhenRevealedComponent>
{
    void Reveal();
    ICommand WhenRevealed { get; }
}
