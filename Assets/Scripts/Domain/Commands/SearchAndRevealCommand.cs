using System;
using System.Collections;

public sealed class SearchAndRevealCommand : BaseSingleCommand
{
    private readonly string CardId;
    private SearchAndRevealCommand(IGame game, string cardId) : base(game) => CardId = cardId;
    public override IEnumerator Execute()
    {
        ICard card = Game.GetFirst(
            AndCompositeSelector.Get(
                CardIdSelector.Get(CardId),
                OrCompositeSelector.Get(
                    LocationSelector.Get("DECK"),
                    LocationSelector.Get("DISCARD")
                )
            ));
        if (card is not null)
        {
            Game.Enqueue(
                CompositeCommand.Get(
                    Game,
                    TransactionCommand.Get(Game, MoveToCommand.Get(Game, card, "BATTLEFIELD")),
                    TransactionCommand.Get(Game, RevealCommand.Get(Game, card))));
        }
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, string cardId) => new SearchAndRevealCommand(game, cardId);
    public static Func<ICard, ICommand> GetFactory(IGame game, string cardId) => (card) => Get(game, cardId);
}
