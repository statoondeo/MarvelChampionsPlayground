public sealed class DealDamageCommand : BaseCommand
{
    private readonly int Damage;
    private readonly ILifeFacade Target;
    private DealDamageCommand(IGame game, ILifeFacade target, int damage) : base(game)
    {
        Damage = damage;
        Target = target;
    }
    public override void Execute() => Target.TakeDamage(Damage);
    public static ICommand Get(IGame game, ILifeFacade target, int damage) => new DealDamageCommand(game, target, damage);
}
