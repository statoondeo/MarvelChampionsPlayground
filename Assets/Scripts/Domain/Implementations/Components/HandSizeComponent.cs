public sealed class HandSizeComponent : IHandSize
{
    public int HandSize { get; private set; }
    public HandSizeComponent(int handSize) => HandSize = handSize;
    public static IHandSize Get(int handSize) => new HandSizeComponent(handSize);

}
public interface IHandSizeFacade : IFacade<IHandSize>, IHandSize { }
public sealed class HandSizeFacade : IHandSizeFacade
{
    private readonly IFacade<IHandSize> Facade;
    private HandSizeFacade(IHandSize item) => Facade = FacadeComponent<IHandSize>.Get(item);

    #region IFacade<IHandSize>

    public IHandSize Item { get; private set; }
    public void AddDecorator(IDecorator<IHandSize> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IHandSize> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IHandSize

    public int HandSize => Item.HandSize;

    #endregion

    public static IHandSizeFacade Get(int handSize) => new HandSizeFacade(HandSizeComponent.Get(handSize));
}