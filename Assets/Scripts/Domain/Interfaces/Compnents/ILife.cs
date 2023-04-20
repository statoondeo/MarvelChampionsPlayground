public interface ILife { int Life { get; } }
public sealed class LifeComponent : ILife
{
    public int Life { get; private set; }
    public LifeComponent(int life) => Life = life;
}