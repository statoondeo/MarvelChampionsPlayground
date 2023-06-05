public interface IFacadeHolder<T> where T : ICardComponent
{
    ICardComponentFacade<T> Facade { get; }
    void SetFacade(ICardComponentFacade<T> facade);
}