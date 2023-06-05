public sealed class StandardCardHolder : ICardHolder
{
    private StandardCardHolder() { }
    public ICard Card { get; private set; }
    public void SetCard(ICard card) => Card = card;
    public static ICardHolder Get() => new StandardCardHolder();
}
