using System.Collections;
using System.Linq;

public sealed class BoardHeroSetupCommand : BaseSingleCommand
{
    private BoardHeroSetupCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => Game.Enqueue(HeroSetupCommand.Get(Game, item.Id)));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new BoardHeroSetupCommand(game);
}