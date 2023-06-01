
using System.Collections;

public sealed class RemoveTreatCommand : BaseSingleCommand
{
    private readonly int Amount;
    private readonly ITreatFacade Target;
    private RemoveTreatCommand(IGame game, ITreatFacade target, int amount) : base(game)
    {
        Amount = amount;
        Target = target;
    }
    public override IEnumerator Execute()
    {
        Target.RemoveTreat(Amount);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ITreatFacade target, int amount) => new RemoveTreatCommand(game, target, amount);
}
