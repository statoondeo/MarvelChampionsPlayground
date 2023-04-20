public interface IAttack { int Attack { get; } }
public sealed class AttackComponent : IAttack
{
    public int Attack {get; private set;}
    public AttackComponent(int attack) => Attack = attack;
}