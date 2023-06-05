public sealed class StandardFacadeHolder<T> : IFacadeHolder<T> where T : ICardComponent
{
    private StandardFacadeHolder() { }
    public ICardComponentFacade<T> Facade { get; private set; }
    public void SetFacade(ICardComponentFacade<T> facade) => Facade = facade;
    public static IFacadeHolder<U> Get<U>() where U : ICardComponent => new StandardFacadeHolder<U>();
}