
public sealed class RemoveTreatCommand : BaseCommand
{
    private readonly int Amount;
    private readonly ITreatFacade Target;
    private RemoveTreatCommand(IGame game, ITreatFacade target, int amount) : base(game)
    {
        Amount = amount;
        Target = target;
    }
    public override void Execute() => Target.RemoveTreat(Amount);
    public static ICommand Get(IGame game, ITreatFacade target, int amount) => new RemoveTreatCommand(game, target, amount);
}
