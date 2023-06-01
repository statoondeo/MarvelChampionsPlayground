using System.Collections;
using System.Linq;

public sealed class BoardDrawUpToHandCommand : BaseSingleCommand
{
    private BoardDrawUpToHandCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => Game.Enqueue(PlayerDrawUpToHandCommand.Get(Game, item.Id)));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new BoardDrawUpToHandCommand(game);
}