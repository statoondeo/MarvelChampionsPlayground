using System.Collections;
using System.Linq;

public sealed class InstallMainSchemeCommand : BaseSingleCommand
{
    private InstallMainSchemeCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(CardTypeSelector.Get(CardType.MainScheme)).ToList()
            .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "BATTLEFIELD")));
        yield return base.Execute();
    }
    public static ICommand Get(IGame game) => new InstallMainSchemeCommand(game);
}
