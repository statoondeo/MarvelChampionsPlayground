public sealed class AddTreatCommand : BaseCommand
{
    private readonly int Amount;
    private readonly ITreatFacade Target;
    private AddTreatCommand(IGame game, ITreatFacade target, int amount) : base(game)
    {
        Amount = amount;
        Target = target;
    }
    public override void Execute() => Target.AddTreat(Amount);
    public static ICommand Get(IGame game, ITreatFacade target, int amount) => new AddTreatCommand(game, target, amount);
}
