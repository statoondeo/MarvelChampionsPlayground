public sealed class LifeComponent : ILife
{
    public int Life { get; private set; }
    private LifeComponent(int life) => Life = life;
    public static ILife Get(int life) => new LifeComponent(life);
}
public interface ILifeFacade : IFacade<ILife>, ILife { }
public sealed class LifeFacade : ILifeFacade
{
    private readonly IFacade<ILife> Facade;
    private LifeFacade(ILife item) => Facade = FacadeComponent<ILife>.Get(item);

    #region IFacade<ILife>

    public ILife Item { get; private set; }
    public void AddDecorator(IDecorator<ILife> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ILife> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ILife

    public int Life => Item.Life;

    #endregion

    public static ILifeFacade Get(int life) => new LifeFacade(LifeComponent.Get(life));
}