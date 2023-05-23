public sealed class GameSetupCommand : ICommand
{
    private readonly ICommand Command;
    private GameSetupCommand(
            ICommand commitGameCommand,
            ICommand installHeroesCommand,
            ICommand setAsidePlayersObligationsCommand,
            ICommand setAsidePlayersNemesisSetCommand,
            ICommand shufflePlayersDecksCommand,
            ICommand createVillainDeckCommand,
            ICommand installVillainsCommand,
            ICommand installMainSchemeCommand,
            ICommand resolveMainSchemeSetupCommand,
            ICommand resolveVillainBoardWhenRevealedCommand,
            ICommand shuffleVillainsDecksCommand,
            ICommand playersDrawHandCommand,
            ICommand playersMulliganCommand,
            ICommand playersSetupCommand
        )
        => Command = CompositeCommand.Get(
                installHeroesCommand, commitGameCommand,
                setAsidePlayersObligationsCommand, commitGameCommand,
                setAsidePlayersNemesisSetCommand, commitGameCommand,
                shufflePlayersDecksCommand, commitGameCommand,
                createVillainDeckCommand, commitGameCommand,
                installVillainsCommand, commitGameCommand,
                installMainSchemeCommand, commitGameCommand,
                resolveMainSchemeSetupCommand, commitGameCommand,
                resolveVillainBoardWhenRevealedCommand, commitGameCommand,
                shuffleVillainsDecksCommand, commitGameCommand,
                playersDrawHandCommand, commitGameCommand,
                playersMulliganCommand, commitGameCommand,
                playersSetupCommand, commitGameCommand
            );
    public void Execute() => Command.Execute();
    public static ICommand Get(IGame game) 
        => new GameSetupCommand(
                CommitGameCommand.Get(game),
                BoardInstallHeroCommand.Get(game),
                BoardSetAsideObligationsCommand.Get(game),
                BoardSetAsideNemesisSetCommand.Get(game),
                ShufflePlayersDecksCommand.Get(game),
                CreateVillainDeckCommand.Get(game),
                BoardInstallVillainCommand.Get(game),
                InstallMainSchemeCommand.Get(game),
                MainSchemeSetupCommand.Get(game),
                ResolveVillainBoardWhenRevealedCommand.Get(game),
                ShuffleVillainsDecksCommand.Get(game),
                BoardDrawUpToHandCommand.Get(game),
                BoardMulligansCommand.Get(game),
                BoardHeroSetupCommand.Get(game)
            );
}