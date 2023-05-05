﻿public sealed class SetAsideNemesisSetCommand : BaseFunctionalCommand
{
    private readonly string PlayerId;
    private SetAsideNemesisSetCommand(IGame game, string playerId) : base(game) => PlayerId = playerId;
    protected override ISelector<ICard> CardSelector
        => PlayerNemesisSetSelector.Get(PlayerId);
    protected override ICommand GetCardCommand(ICard card)
        => CompositeCommand.Get(
                MoveToCommand.Get(Game, card, "EXIL"),
                FlipToCommand.Get(Game, card, "FACE"));
    public static ICommand Get(IGame game, string playerId) => new SetAsideNemesisSetCommand(game, playerId);
}