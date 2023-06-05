public abstract class BaseCardComponentDecorator<T> : ICardComponentDecorator<T> where T : ICardComponent
{
    protected BaseCardComponentDecorator() { }

    #region ICardComponentDecorator

    public ICardComponentFacade<T> Facade { get; protected set; }
    public ICardComponent<T> Inner { get; protected set; }
    protected T InnerComponent => (T)Inner;

    public ICardComponentDecorator<T> Wrap(ICardComponent<T> wrapped)
    {
        Inner = wrapped;
        return this;
    }
    public void SetFacade(ICardComponentFacade<T> facade) => Facade = facade;

    #endregion

    #region ICardComponent

    public void Init() => Inner.Init();

    #endregion

    #region ICardHolder

    public ICard Card => Inner.Card;
    public void SetCard(ICard card) => Inner.SetCard(card);

    #endregion
}