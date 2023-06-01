using System.Collections;

public sealed class AddTreatCommand : BaseSingleCommand
{
    private readonly int Amount;
    private readonly ITreatFacade Target;
    private AddTreatCommand(IGame game, ITreatFacade target, int amount) : base(game)
    {
        Amount = amount;
        Target = target;
    }
    public override IEnumerator Execute()
    {
        Target.AddTreat(Amount);
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, ITreatFacade target, int amount) => new AddTreatCommand(game, target, amount);
}
