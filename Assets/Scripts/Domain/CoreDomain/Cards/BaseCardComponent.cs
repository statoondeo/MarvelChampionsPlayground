public abstract class BaseCardComponent<T> : BaseComponent, ICardComponent<T> where T : ICardComponent
{
    protected BaseCardComponent() : base() => CardHolder = StandardCardHolder.Get();

    #region ICardHolder

    protected ICardHolder CardHolder;
    public ICard Card { get; protected set; }
    public virtual void SetCard(ICard card) => Card = card;

    #endregion
}
