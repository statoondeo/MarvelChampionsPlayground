public sealed class GameSetupCommand
{
    private GameSetupCommand() { }
    public static ICommand Get(IGame game)
    {
        return CompositeCommand.Get( 
                    game,
                    TransactionCommand.Get(game, BoardInstallHeroCommand.Get(game)),
                    TransactionCommand.Get(game, BoardSetAsideObligationsCommand.Get(game)),
                    TransactionCommand.Get(game, BoardSetAsideNemesisSetCommand.Get(game)),
                    TransactionCommand.Get(game, ShufflePlayersDecksCommand.Get(game)),
                    TransactionCommand.Get(game, CreateVillainDeckCommand.Get(game)),
                    TransactionCommand.Get(game, BoardInstallVillainCommand.Get(game)),
                    TransactionCommand.Get(game, MainSchemeSetupCommand.Get(game)),
                    TransactionCommand.Get(game, ResolveVillainBoardWhenRevealedCommand.Get(game)),
                    TransactionCommand.Get(game, ShuffleVillainsDecksCommand.Get(game)),
                    TransactionCommand.Get(game, BoardDrawUpToHandCommand.Get(game)),
                    TransactionCommand.Get(game, BoardMulligansCommand.Get(game)),
                    TransactionCommand.Get(game, BoardHeroSetupCommand.Get(game))
                );
    }
}