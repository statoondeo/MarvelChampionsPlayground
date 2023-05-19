public sealed class AttackComponent : BaseCardComponent<IAttackComponent>, IAttackComponent
{
    public int Attack { get; private set; }
    private AttackComponent(int attack) : base()
    {
        Attack = attack;
    }
    public static IAttackComponent Get(int attack)
        => new AttackComponent(attack);
}
