using System.Collections;

public sealed class ResolveCardCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private ResolveCardCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        (Card.CurrentFace as ICostComponent).Resolve();
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, ICard card) => new ResolveCardCommand(game, card);
}

