public interface IWhenRevealedComponent : ICardComponent<IWhenRevealedComponent>
{
    ICommand WhenRevealed { get; }
}
