using System.Collections;

public sealed class DealDamageCommand : BaseSingleCommand
{
    private readonly int Damage;
    private readonly ILifeFacade Target;
    private DealDamageCommand(IGame game, ILifeFacade target, int damage) : base(game)
    {
        Damage = damage;
        Target = target;
    }
    public override IEnumerator Execute()
    {
        Target.TakeDamage(Damage);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ILifeFacade target, int damage) => new DealDamageCommand(game, target, damage);
}
