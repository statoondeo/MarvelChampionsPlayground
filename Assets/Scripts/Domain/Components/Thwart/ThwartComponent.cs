public sealed class ThwartComponent : BaseComponent<IThwartComponent>, IThwartComponent
{
    public int Thwart { get; private set; }
    private ThwartComponent(int thwart) : base () => Thwart = thwart;
    public static IThwartComponent Get(int thwart) => new ThwartComponent(thwart);
}
