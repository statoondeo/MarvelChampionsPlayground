public sealed class ThwartComponent : IThwart
{
    public int Thwart { get; private set; }
    private ThwartComponent(int thwart) => Thwart = thwart;
    public static IThwart Get(int thwart) => new ThwartComponent(thwart);
}
public interface IThwartFacade : IFacade<IThwart>, IThwart { }
public sealed class ThwartFacade : IThwartFacade
{
    private readonly IFacade<IThwart> Facade;
    private ThwartFacade(IThwart item) => Facade = FacadeComponent<IThwart>.Get(item);

    #region IFacade<IThwart>

    public IThwart Item { get; private set; }
    public void AddDecorator(IDecorator<IThwart> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IThwart> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IThwart

    public int Thwart => Item.Thwart;

    #endregion

    public static IThwartFacade Get(int thwart) => new ThwartFacade(ThwartComponent.Get(thwart));

}