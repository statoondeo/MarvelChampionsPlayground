public interface IThwart { int Thwart { get; } }
public sealed class ThwartComponent : IThwart
{
    public int Thwart { get; private set; }
    public ThwartComponent(int thwart) => Thwart = thwart;
}