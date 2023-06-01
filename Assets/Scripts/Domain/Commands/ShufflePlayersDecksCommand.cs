using System.Collections;
using System.Linq;

public sealed class ShufflePlayersDecksCommand : BaseSingleCommand
{
    public ShufflePlayersDecksCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Hero)).ToList()
            .ForEach(item => Game.Enqueue(ShuffleDeckCommand.Get(Game, item.GetZone("DECK"))));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new ShufflePlayersDecksCommand(game);
}
