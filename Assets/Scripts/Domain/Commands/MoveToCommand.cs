using System.Collections;

using UnityEngine;

public sealed class MoveToCommand : BaseSingleCommand
{
    private readonly string Location;
    private readonly ICard Card;
    private MoveToCommand(IGame game, ICard card, string location) : base(game)
    {
        Location = location;
        Card = card;
    }
    public override IEnumerator Execute()
    {
        Card.MoveTo(Location);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ICard card, string location) => new MoveToCommand(game, card, location);
}
