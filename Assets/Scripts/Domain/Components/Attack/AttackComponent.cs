public sealed class AttackComponent : BaseComponent<IAttackComponent>, IAttackComponent
{
    public int Attack { get; private set; }
    private AttackComponent(int attack) : base()
    {
        Type = ComponentType.Attack;
        Attack = attack;
    }
    public static IAttackComponent Get(int attack)
        => new AttackComponent(attack);
}
