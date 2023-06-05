using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public sealed class MulliganCommand : BaseSingleCommand, IPickReceiver<ICard>
{
    private int Step;
    private IEnumerable<ICard> SelectedItems;
    private readonly string PlayerId;
    private MulliganCommand(IGame game, string playerId) : base(game)
    {
        PlayerId = playerId;
        Step = 0;
    }
    private ISelector<ICard> CardSelector
        => AndCompositeSelector.Get(
            OwnerIdSelector.Get(PlayerId),
            LocationSelector.Get("HAND"));
    public void Receive(IEnumerable<ICard> items) => SelectedItems = items;
    public override IEnumerator Execute()
    {
        switch (Step)
        {
            case 0:
                yield return Game.Pick(Game.GetAll(CardSelector), this, "Mulligan", "Choisissez les cartes à défausser");
                SelectedItems.ToList().ForEach(item => Game.Enqueue(MoveToCommand.Get(Game, item, "DISCARD")));
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
