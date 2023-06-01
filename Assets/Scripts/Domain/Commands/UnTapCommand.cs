using System.Collections;

public sealed class UnTapCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private UnTapCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        Card.UnTap();
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, ICard card) => new UnTapCommand(game, card);
}
