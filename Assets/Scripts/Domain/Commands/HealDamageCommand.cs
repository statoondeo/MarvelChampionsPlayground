public sealed class HealDamageCommand : BaseCommand
{
    private readonly int Damage;
    private readonly ILifeFacade Target;
    private HealDamageCommand(IGame game, ILifeFacade target, int damage) : base(game)
    {
        Damage = damage;
        Target = target;
    }
    public override void Execute() => Target.HealDamage(Damage);
    public static ICommand Get(IGame game, ILifeFacade target, int damage) => new HealDamageCommand(game, target, damage);
}
