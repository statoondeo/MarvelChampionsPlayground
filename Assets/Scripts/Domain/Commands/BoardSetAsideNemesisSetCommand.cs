using System.Collections;
using System.Linq;

public sealed class BoardSetAsideNemesisSetCommand : BaseSingleCommand
{
    public BoardSetAsideNemesisSetCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => Game.Enqueue(SetAsideNemesisSetCommand.Get(Game, item.Id)));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new BoardSetAsideNemesisSetCommand(game);
}
