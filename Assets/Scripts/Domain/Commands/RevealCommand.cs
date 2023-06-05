using System.Collections;

public sealed class RevealCommand : BaseSingleCommand
{
    private readonly ICard Card;
    private RevealCommand(IGame game, ICard card) : base(game) => Card = card;
    public override IEnumerator Execute()
    {
        ICommand command = Card.CurrentFace.GetFacade<IWhenRevealedComponent>()?.WhenRevealed;
        if (command is not null) Game.Enqueue(command);
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, ICard card) => new RevealCommand(game, card);
}