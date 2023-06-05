public abstract class BaseCardComponent<T> : BaseComponent, ICardComponent<T> where T : ICardComponent
{
    protected BaseCardComponent() : base()
    {
        CardHolder = StandardCardHolder.Get();
        FacadeHolder = StandardFacadeHolder<T>.Get<T>();
    }

    #region ICardHolder

    protected ICardHolder CardHolder;
    public ICard Card { get; protected set; }
    public virtual void SetCard(ICard card) => Card = card;

    #endregion


    #region IFacadeHolder

    protected IFacadeHolder<T> FacadeHolder;
    public ICardComponentFacade<T> Facade { get; protected set; }
    public virtual void SetFacade(ICardComponentFacade<T> facade) => Facade = facade;

    #endregion
}
