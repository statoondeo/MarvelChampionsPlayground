public interface IDefense { int Defense { get; } }
public sealed class DefenseComponent : IDefense { 
    public int Defense { get; private set; }
    public DefenseComponent(int defence) => Defense = defence;
}