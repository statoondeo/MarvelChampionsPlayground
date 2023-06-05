using System;
using System.Collections;

public sealed class HinderCommand : BaseSingleCommand
{
    private readonly int Value;
    private readonly ICard Card;
    private HinderCommand(IGame game, ICard card, int value) : base(game)
    {
        Value = value;
        Card = card;
    }

    public override IEnumerator Execute()
    {
        if (Card.CurrentFace is ITreatFacade cardFacade)
            cardFacade.AddTreat(Value);
        yield return base.Execute();
    }
    public static ICommand Get(IGame game, ICard card, int value) => new HinderCommand(game, card, value);
    public static Func<ICard, ICommand> GetFactory(IGame game, int value) => (card) => Get(game, card, value);
}
