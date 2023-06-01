using System.Collections;

public sealed class HealDamageCommand : BaseSingleCommand
{
    private readonly int Damage;
    private readonly ILifeFacade Target;
    private HealDamageCommand(IGame game, ILifeFacade target, int damage) : base(game)
    {
        Damage = damage;
        Target = target;
    }
    public override IEnumerator Execute()
    {
        Target.HealDamage(Damage);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ILifeFacade target, int damage) => new HealDamageCommand(game, target, damage);
}
