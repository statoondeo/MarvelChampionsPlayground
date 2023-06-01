using System.Collections;
using System.Linq;

public sealed class ShuffleVillainsDecksCommand : BaseSingleCommand
{
    public ShuffleVillainsDecksCommand(IGame game) : base(game) { }
    public override IEnumerator Execute()
    {
        Game.GetAll(PlayerTypeSelector.Get(HeroType.Villain)).ToList()
            .ForEach(item => Game.Enqueue(ShuffleDeckCommand.Get(Game, item.GetZone("DECK"))));
        yield return base.Execute();
    }

    public static ICommand Get(IGame game) => new ShuffleVillainsDecksCommand(game);
}
