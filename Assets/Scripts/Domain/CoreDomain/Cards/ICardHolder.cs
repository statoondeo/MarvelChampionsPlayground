public interface ICardHolder
{
    ICard Card { get; }
    void SetCard(ICard card);
}