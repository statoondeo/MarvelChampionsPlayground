public sealed class DefenseComponent : IDefense 
{ 
    public int Defense { get; private set; }
    public DefenseComponent(int defence) => Defense = defence;
    public static IDefense Get(int defence) => new DefenseComponent(defence);
}