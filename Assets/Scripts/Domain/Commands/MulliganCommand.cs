using System.Collections;
using System.Linq;

public sealed class MulliganCommand : BaseSingleCommand
{
    private int Step;
    private readonly string PlayerId;
    private readonly IPickReceiver<ICard> PickReceiver;
    private MulliganCommand(IGame game, string playerId) : base(game)
    {
        PlayerId = playerId;
        Step = 0;
        PickReceiver = StandardCardPickReceiver.Get();
    }
    private ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            OwnerIdSelector.Get(PlayerId),
            LocationSelector.Get("HAND"));
    public override IEnumerator Execute()
    {
        switch (Step)
        {
            case 0:
                yield return Game.Pick(CardSelector, PickReceiver, "Mulligan", "Choisissez les cartes à défausser, puis OK");
                PickReceiver.SelectedItems
                    .ToList()
                    .ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "DISCARD")));
                Step++;
                yield return null;
                break;
            case 1:
                Game.Enqueue(PlayerDrawUpToHandCommand.Get(Game, PlayerId));
                Step++;
                yield return null;
                break;
            default:
                yield return base.Execute();
                break;
        }
        
    }
    public static ICommand Get(IGame game, string playerId) => new MulliganCommand(game, playerId);
}
